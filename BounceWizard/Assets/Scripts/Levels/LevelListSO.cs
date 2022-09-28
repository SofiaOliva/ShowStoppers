using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "SO/Levels/LevelList")]
public class LevelListSO : ScriptableObject
{
    public LevelSO[] levels;
}
