using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode{NoiseMap, ColorMap, Mesh}; 
    public DrawMode drawMode; 

    const int mapChunckSize = 241; 
    [Range(0,6)]
    public int levelOfDetail; 

    public float noiseScale; 
    public bool autoUpdate; 

    public int octaves; 
    [Range(0,1)]
    public float persistance; 
    public float lacunarity; 

    public float meshHeightMultiplier; 
    public AnimationCurve meshHeightCurve; 

    public int seed; 
    public Vector2 offset; 

    public TerrainType[] regions; 

    public void GenerateMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunckSize, mapChunckSize, seed, noiseScale, 
        octaves, persistance, lacunarity, offset); 

        Color[] colorMap = new Color[mapChunckSize * mapChunckSize]; 
        for(int y=0; y<mapChunckSize; y++){
            for(int x=0; x<mapChunckSize; x++){
                float currentHeight = noiseMap[x,y]; 
                for(int i=0; i<regions.Length; i++){
                    if(currentHeight <= regions[i].height){
                        colorMap[y * mapChunckSize + x] = regions[i].color; 
                        break; 
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>(); 
        if(drawMode == DrawMode.NoiseMap){
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap)); 
        }
        else if(drawMode == DrawMode.ColorMap){
           display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapChunckSize, mapChunckSize)); 
        }
        else if(drawMode == DrawMode.Mesh){
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColorMap(colorMap, mapChunckSize, mapChunckSize)); 
        }
    }

    void OnValidate(){
        if(lacunarity < 1){
            lacunarity = 1;
        }
        if(octaves < 0){
            octaves = 0; 
        }
    }
}

[System.Serializable]
public struct TerrainType{
    public string name; 
    public float height; 
    public Color color; 
}
