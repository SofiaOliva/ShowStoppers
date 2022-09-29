using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "SO/GameData")]
public class GameDataSO : ScriptableObject
{
    [Tooltip("0: First level, 1: Second level, etc.")]
    public int level;
    [Tooltip("Check this to replay the level after winning it")]
    public bool DEBUG_freezeLevel = false;
    public LevelPlanSO levelPlan;

    public void WinLevel()
    {
        if (Application.isEditor && DEBUG_freezeLevel) return;
        ++level;
    }

    public bool HasFinished()
    {
        return !levelPlan.IsValidLevel(level);
    }

    public void Reset()
    {
        if (Application.isEditor && DEBUG_freezeLevel) return;
        level = 0;
    }
}
