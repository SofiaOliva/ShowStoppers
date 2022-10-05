using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [Header("Optional Randomization")]
    public int seed;
    public bool randomSeed;
    [Header("Level Stats")]
    public int enemyCount = 1;
    public int allyCount = 1;

    public GameObject specifiedMap;
    public MapListSO randomMapList;

    public int Seed
    {
        get
        {
            if (randomSeed)
            {
                return Random.Range(0, 100);
            }
            else
            {
                return seed;
            }
        }

    }

    public GameObject GetMap()
    {
        if (specifiedMap)
        {
            return specifiedMap;
        }
        else
        {
            return randomMapList.GetRandomMap();
        }
    }
}
