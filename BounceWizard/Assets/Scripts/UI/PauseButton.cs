using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] EventSO_Bool pauseEvent;

    public void SetPause(bool pause)
    {
        pauseEvent.Trigger(pause);
    }
}
