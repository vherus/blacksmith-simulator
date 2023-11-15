using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OreResource", menuName = "Ore Resources")]
public class OreResource : ScriptableObject
{
    public OreType OreType;
    public int MaxOre;
}
