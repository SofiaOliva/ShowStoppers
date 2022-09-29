using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Campaign", menuName = "SO/Levels/LevelPlan/Campaign")]
public class LevelPlanCampaignSO : LevelPlanSO
{
    public LevelListSO levels;
    public override Level GetLevel(int number)
    {
        return levels.levels[number].level;
    }

    public override bool IsValidLevel(int number)
    {
        return number < levels.levels.Length;
    }
}
