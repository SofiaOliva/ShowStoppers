using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSO_LevelResults", menuName = "EventsSO/LevelResults")]
public class EventSO_LevelResults : EventSO<LevelResults>
{
}

public struct LevelResults
{
    public bool victory;
    public string message;
    public GameDataSO gameData;

    public LevelResults(bool _victory, GameDataSO _gameData, string _message = "")
    {
        victory = _victory;
        message = _message;
        gameData = _gameData;
    }
}
