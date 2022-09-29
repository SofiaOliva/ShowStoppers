using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameDataSO gameData;

    [SerializeField] LevelGenerator levelGenerator;

    public void Start()
    {
        InitializeLevel(gameData.levelPlan.GetLevel(gameData.level));
    }

    public void InitializeLevel(Level level)
    {
        levelGenerator.Generate(level);
    }
}
