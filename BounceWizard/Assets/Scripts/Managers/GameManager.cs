using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InitializeLevel(gameData.levelPlan.GetLevel(gameData.level));
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
        Lose();
    }

    void OnAllAlliesDead()
    {
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
        if (!gameData.HasFinished())
        {
            transitionEvent.Trigger(new SceneTransition("Game"));
        }
        else
        {
            print("You beat all the levels! Restarting...");
            gameData.Reset();
            transitionEvent.Trigger(new SceneTransition("Game", 2f));
        }
    }

    void Lose()
    {
        if (!levelPlaying) return;
        EndLevel();
        print("You lost! Restarting...");
        gameData.Reset();
        transitionEvent.Trigger(new SceneTransition("Game", 2f));
    }
}
