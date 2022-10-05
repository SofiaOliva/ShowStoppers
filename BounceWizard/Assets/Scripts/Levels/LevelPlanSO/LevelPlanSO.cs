using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelPlanSO : ScriptableObject
{
    public GameObject failScreen;
    public GameObject winScreen;

    public EventSO_SceneTransition transitionEvent;

    /// <summary>
    /// Given the level number, return instructions for how to generate it.
    /// </summary>
    public abstract Level GetLevel(int number);

    public abstract bool IsValidLevel(int number);

    public virtual void WinLevel(int index) {
        GoScene(SceneManager.GetActiveScene().name);
    }
    protected void GoScene(string sceneName)
    {
        transitionEvent.Trigger(new SceneTransition(sceneName, 1f));
    }
    public virtual void EndLevel(GameDataSO data) { }
}
