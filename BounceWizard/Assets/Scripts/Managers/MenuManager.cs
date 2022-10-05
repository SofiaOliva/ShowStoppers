using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameDataSO gameData;
    public LevelPlanSO campaignPlan;
    public LevelPlanSO endlessPlan;
    public EventSO_SceneTransition transitionEvent;

    private void Start()
    {
        gameData.Reset();
    }

    public void PlayCampaign()
    {
        gameData.levelPlan = campaignPlan;
        gameData.manaPool.UnlockStreams(0);
        Play("Dialogue");
    }

    public void PlayEndless()
    {
        gameData.levelPlan = endlessPlan;
        gameData.manaPool.UnlockStreams(2);
        Play();
    }

    void Play(string sceneName = "Game")
    {
        gameData.Level = 0;
        transitionEvent.Trigger(new SceneTransition(sceneName, 1f));
    }
}
