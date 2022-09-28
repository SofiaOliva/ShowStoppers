using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelPlanSO : ScriptableObject
{
    /// <summary>
    /// Given the level number, return instructions for how to generate it.
    /// </summary>
    public abstract Level GetLevel(int number);

    public abstract bool IsLastLevel(int number);
}
