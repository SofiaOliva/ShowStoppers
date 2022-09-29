using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "SO/GameData")]
public class GameDataSO : ScriptableObject
{
    public int level;
    public LevelPlanSO levelPlan;
}
