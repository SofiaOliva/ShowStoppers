using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Endless", menuName = "SO/Levels/LevelPlan/Endless")]
public class LevelPlanEndlessSO : LevelPlanSO
{
    public MapListSO mapList;
    public override Level GetLevel(int number)
    {
        Level newLevel = new Level();
        newLevel.allyCount = (number+1) / 3 + 1;
        newLevel.enemyCount = number+1;
        newLevel.mapList = mapList;
        newLevel.randomSeed = true;

        return newLevel;
    }

    public override bool IsValidLevel(int number)
    {
        return true;
    }

    public override void EndLevel(GameDataSO data)
    {
        data.Reset();
    }
}
