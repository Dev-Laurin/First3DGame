using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    const float viewerMoveThresholdForChunkUpdate = 25f; 
    const float sqrViewerMoveThresholdForChunkUpdate = viewerMoveThresholdForChunkUpdate * viewerMoveThresholdForChunkUpdate; 

    public static float maxViewDist; 
    public LODInfo[] detailLevels; 

    public Transform viewer; 
    public Material mapMaterial; 

    public static Vector2 viewerPos; 
    Vector2 viewerPositionOld; 
    static MapGenerator mapGenerator; 
    int chunkSize; 
    int chunksVisibleInViewDist; 

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>(); 
    static List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>(); 

    void Start(){
        mapGenerator = FindObjectOfType<MapGenerator>(); 

        maxViewDist = detailLevels[detailLevels.Length - 1].visibleDistThreshold; 
        chunkSize = mapGenerator.mapChunkSize - 1; 
        chunksVisibleInViewDist = Mathf.RoundToInt(maxViewDist / chunkSize); 

        UpdateVisibleChunks(); 
    }

    void Update(){
        viewerPos = new Vector2(viewer.position.x, viewer.position.z) / mapGenerator.terrainData.uniformScale; 
        if((viewerPositionOld-viewerPos).sqrMagnitude > sqrViewerMoveThresholdForChunkUpdate){
            viewerPositionOld = viewerPos; 
            UpdateVisibleChunks(); 
        }
    }

    void UpdateVisibleChunks(){
        for (int i=0; i<terrainChunksVisibleLastUpdate.Count; i++){
            terrainChunksVisibleLastUpdate[i].SetVisible(false); 
        }
        terrainChunksVisibleLastUpdate.Clear(); 

        int currentChunkCoordX = Mathf.RoundToInt(viewerPos.x/chunkSize); 
        int currentChunkCoordY = Mathf.RoundToInt(viewerPos.y/chunkSize);

        for(int yOffset = -chunksVisibleInViewDist; yOffset <= chunksVisibleInViewDist; yOffset++){
            for(int xOffset = -chunksVisibleInViewDist; xOffset <= chunksVisibleInViewDist; xOffset++){
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset); 

                if(terrainChunkDictionary.ContainsKey(viewedChunkCoord)){
                    terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk(); 
                }
                else{
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize, detailLevels, transform, mapMaterial)); 
                }
            }
        }
    }

    public class TerrainChunk{
        Vector2 pos; 
        GameObject meshObject;
        Bounds bounds;  

        MapData mapData; 

        MeshRenderer meshRenderer; 
        MeshFilter meshFilter; 
        MeshCollider meshCollider; 

        LODInfo[] detailLevels; 
        LODMesh[] lodMeshes; 
        LODMesh collisionLODMesh; 

        bool mapDataReceived; 

        int previousLODIndex = -1; 

        public TerrainChunk(Vector2 coord, int size, LODInfo[] detailLevels, Transform parent, Material material){
            this.detailLevels = detailLevels; 

            pos = coord * size; 
            bounds = new Bounds(pos, Vector2.one * size); 
            Vector3 positionV3 = new Vector3(pos.x, 0, pos.y); 

            meshObject = new GameObject("Terrain Chunk"); 
            meshRenderer = meshObject.AddComponent<MeshRenderer>();
            meshRenderer.material = material;  
            meshFilter = meshObject.AddComponent<MeshFilter>(); 
            meshCollider = meshObject.AddComponent<MeshCollider>(); 
            meshObject.transform.position = positionV3 * mapGenerator.terrainData.uniformScale; 
            meshObject.transform.parent = parent; 
            meshObject.transform.localScale = Vector3.one * mapGenerator.terrainData.uniformScale; 
            SetVisible(false); 

            lodMeshes = new LODMesh[detailLevels.Length]; 
            for(int i=0; i<detailLevels.Length; i++){
                lodMeshes[i] = new LODMesh(detailLevels[i].lod, UpdateTerrainChunk);
                if(detailLevels[i].useForCollider){
                    collisionLODMesh = lodMeshes[i]; 
                } 
            }

            mapGenerator.RequestMapData(pos, OnMapDataReceived); 
        }

        void OnMapDataReceived(MapData mapData){
           this.mapData = mapData;  
           mapDataReceived = true; 

           UpdateTerrainChunk(); 
        }

        public void UpdateTerrainChunk(){
            if(mapDataReceived){
                float viewerDistFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPos)); 
                bool visible = viewerDistFromNearestEdge <= maxViewDist; 

                if(visible){
                    int lodIndex = 0; 

                    for(int i=0; i<detailLevels.Length-1; i++){
                        if(viewerDistFromNearestEdge > detailLevels[i].visibleDistThreshold){
                            lodIndex = i + 1; 
                        }
                        else{
                            break; 
                        }
                    }

                    if(lodIndex != previousLODIndex){
                        LODMesh lodMesh = lodMeshes[lodIndex]; 
                        if(lodMesh.hasMesh){
                            previousLODIndex = lodIndex; 
                            meshFilter.mesh = lodMesh.mesh; 
                             
                        }
                        else if(!lodMesh.hasRequestedMesh){
                            lodMesh.RequestMesh(mapData); 
                        }
                    }

                    if(lodIndex == 0){
                        if(collisionLODMesh.hasMesh){
                            meshCollider.sharedMesh = collisionLODMesh.mesh; 
                        }
                        else if(!collisionLODMesh.hasRequestedMesh){
                            collisionLODMesh.RequestMesh(mapData); 
                        }
                    }

                    terrainChunksVisibleLastUpdate.Add(this); 
                }
                SetVisible(visible); 
            } 
        }

        public void SetVisible(bool visible){
            meshObject.SetActive(visible); 
        }

        public bool IsVisible(){
            return meshObject.activeSelf; 
        }
    }

    class LODMesh{
        public Mesh mesh; 
        public bool hasRequestedMesh; 
        public bool hasMesh; 

        System.Action updateCallback; 

        int lod; 

        public LODMesh(int lod, System.Action updateCallback){
            this.lod = lod; 
            this.updateCallback = updateCallback; 
        }

        void OnMeshDataReceived(MeshData meshData){
            mesh = meshData.CreateMesh(); 
            hasMesh = true; 

            updateCallback(); 
        }

        public void RequestMesh(MapData mapData){
            hasRequestedMesh = true; 
            mapGenerator.RequestMeshData(mapData, lod, OnMeshDataReceived); 
        }
    }

    [System.Serializable]
    public struct LODInfo{
        public int lod; 
        public float visibleDistThreshold; 
        public bool useForCollider; 
    }
}
