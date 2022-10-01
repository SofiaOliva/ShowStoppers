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

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            if (Application.isEditor && DEBUG_freezeLevel) return;
            level = value;
        }
    }

    public void WinLevel()
    {
        ++Level;
    }

    public bool HasFinished()
    {
        return !levelPlan.IsValidLevel(Level);
    }

    public void Reset()
    {
        Level = 0;
    }
}
