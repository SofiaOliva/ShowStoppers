using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject levelEndScreen;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public EventSO_LevelResults resultsEvent;
    public EventSO_SceneTransition transitionEvent;

    private void Awake()
    {
        levelEndScreen.SetActive(false);
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    private void OnEnable()
    {
        resultsEvent.Event += OnLevelResults;
    }

    private void OnDisable()
    {
        resultsEvent.Event -= OnLevelResults;
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
        if (results.victory)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            gameOverText.text = results.message;
            gameOverScreen.SetActive(true);

        }
        levelEndScreen.SetActive(true);
    }
}
