using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public GameObject levelEndScreen;
    //public GameObject victoryScreen;
    //public GameObject gameOverScreen;
    //public TMP_Text gameOverText;
    public EventSO_LevelResults resultsEvent;
    public EventSO_SceneTransition transitionEvent;
    public EventSO_Bool pauseEvent;
    public GameObject pauseScreen;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        OnPause(false);
        //levelEndScreen.SetActive(false);
        //victoryScreen.SetActive(false);
        //gameOverScreen.SetActive(false);
    }

    private void OnEnable()
    {
        resultsEvent.Event += OnLevelResults;
        pauseEvent.Event += OnPause;
    }

    private void OnDisable()
    {
        resultsEvent.Event -= OnLevelResults;
        pauseEvent.Event -= OnPause;
    }

    public void OnPause(bool newPause)
    {
        pauseScreen.SetActive(newPause);
    }

    public void Retry()
    {
        transitionEvent.Trigger(new SceneTransition(SceneManager.GetActiveScene().name, 0.5f));
    }

    public void Quit()
    {
        transitionEvent.Trigger(new SceneTransition("Menu", 2f));
    }

    void OnLevelResults(LevelResults results)
    {
        LevelPlanSO plan = results.gameData.levelPlan;
        GameObject screen = Instantiate(results.victory ? plan.winScreen : plan.failScreen);
        screen.transform.SetParent(canvas.transform);
        screen.transform.localScale = Vector3.one;
        screen.transform.localPosition = Vector3.zero;
        screen.GetComponent<LevelEndScreen>().SetResults(results);
    }
}
