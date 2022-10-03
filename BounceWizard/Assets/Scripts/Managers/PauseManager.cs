using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;
    public EventSO_Bool pauseEvent;

    private void OnEnable()
    {
        pauseEvent.Event += OnPause;
    }

    private void OnDisable()
    {
        pauseEvent.Event -= OnPause;
    }

    private void Start()
    {
        isPaused = true;
        SetPause(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }


    void TogglePause()
    {
        SetPause(!isPaused);
    }

    void OnPause(bool newPause)
    {
        SetPause(newPause);
    }

    void SetPause(bool newPause)
    {
        if (isPaused == newPause) return;
        isPaused = newPause;
        pauseEvent.Trigger(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
