using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameDataSO gameData;
    public LevelPlanSO campaignPlan;
    public LevelPlanSO endlessPlan;
    public EventSO_SceneTransition transitionEvent;

    public void PlayCampaign()
    {
        gameData.levelPlan = campaignPlan;
        Play();
    }

    public void PlayEndless()
    {
        gameData.levelPlan = endlessPlan;
        Play();
    }

    void Play()
    {
        gameData.Level = 0;
        transitionEvent.Trigger(new SceneTransition("Game", 1f));
    }
}
