using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game progression")]
    public GameDataSO gameData;

    [Header("Generation")]
    [SerializeField] LevelGenerator levelGenerator;

    [Header("Game logic")]
    public RuntimeSet_Entity player;
    public RuntimeSet_Entity enemies;
    public RuntimeSet_Entity allies;

    public EventSO_LevelResults levelResultsEvent;
    public EventSO_SceneTransition transitionEvent;

    bool levelPlaying = false;

    private void OnEnable()
    {
        //enemies.EmptyEvent += OnAllEnemiesDead;
        player.EmptyEvent += OnPlayerDead;
    }

    private void OnDisable()
    {
        player.EmptyEvent -= OnPlayerDead;
        enemies.EmptyEvent -= OnAllEnemiesDead;
        allies.EmptyEvent -= OnAllAlliesDead;
    }

    public void Start()
    {
        InitializeLevel(gameData.levelPlan.GetLevel(gameData.Level));
        enemies.EmptyEvent += OnAllEnemiesDead;
        allies.EmptyEvent += OnAllAlliesDead;

        levelPlaying = true;
    }

    public void InitializeLevel(Level level)
    {
        levelGenerator.Generate(level);
    }

    void OnAllEnemiesDead()
    {
        Win();
    }

    void OnPlayerDead()
    {
        if (!levelPlaying) return;
        levelResultsEvent.Trigger(new LevelResults(false, gameData, "You were slain!"));
        Lose();
    }

    void OnAllAlliesDead()
    {
        if (!levelPlaying) return;
        levelResultsEvent.Trigger(new LevelResults(false, gameData, "All allies were slain!"));
        Lose();
    }

    void EndLevel()
    {
        levelPlaying = false;
    }

    void Win()
    {
        if (!levelPlaying) return;
        EndLevel();
        gameData.WinLevel();
        float transitionTime = 1f;
        if (gameData.HasFinished())
        {
            print("You beat all the levels!");
            gameData.Reset();
            transitionTime = 2f;
            levelResultsEvent.Trigger(new LevelResults(true, gameData));
            //transitionEvent.Trigger(new SceneTransition("Menu", 2f));
        }
        else
        {
            transitionEvent.Trigger(new SceneTransition(SceneManager.GetActiveScene().name, transitionTime));
        }
        
    }

    void Lose()
    {
        //if (!levelPlaying) return;
        EndLevel();
        print("You lost!");
        gameData.levelPlan.EndLevel(gameData);
        //transitionEvent.Trigger(new SceneTransition("Menu", 2f));
    }
}
