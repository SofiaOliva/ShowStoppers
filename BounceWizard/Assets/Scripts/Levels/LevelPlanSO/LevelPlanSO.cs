using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelPlanSO : ScriptableObject
{
    public GameObject failScreen;
    public GameObject winScreen;

    /// <summary>
    /// Given the level number, return instructions for how to generate it.
    /// </summary>
    public abstract Level GetLevel(int number);

    public abstract bool IsValidLevel(int number);

    public virtual void WinLevel(int index) { }
    public abstract void EndLevel(GameDataSO data);
}
