using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Terrain Data", menuName="Procedural Generation/TerrainData")]
public class TerrainData : UpdateableData
{
    public float meshHeightMultiplier; 
    public AnimationCurve meshHeightCurve;  

    public bool useFallOff;

    public float uniformScale = 2.5f; 
}
