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

    public LevelResults(bool _victory, string _message = "")
    {
        victory = _victory;
        message = _message;
    }
}
