using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapList", menuName = "SO/Levels/MapList")]
public class MapListSO : ScriptableObject
{
    public GameObject[] maps;

    public GameObject GetRandomMap()
    {
        return maps[Random.Range(0, maps.Length)];
    }
}
