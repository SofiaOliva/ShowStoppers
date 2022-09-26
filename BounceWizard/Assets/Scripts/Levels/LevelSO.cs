using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "SO/Levels/LevelSo")]
public class LevelSO : ScriptableObject
{
    [Header("Optional Randomization")]
    public int seed;
    public bool randomSeed;
    [Header("Level Stats")]
    public int enemyCount = 1;
    public int allyCount = 1;

    public MapListSO mapList;

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
}
