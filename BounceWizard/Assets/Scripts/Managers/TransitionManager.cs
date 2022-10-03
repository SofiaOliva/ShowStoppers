using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public EventSO_SceneTransition transitionEvent;

    private bool isTransitioning = false;

    private void OnEnable()
    {
        transitionEvent.Event += Transition;
    }

    private void OnDisable()
    {
        transitionEvent.Event -= Transition;
    }

    void Transition(SceneTransition transition)
    {
        if (isTransitioning) return;
        isTransitioning = true;
        print("Transitioning to scene " + transition.sceneName);
        StartCoroutine(Transitioning(transition));
        GetComponentInChildren<ScreenWipe>().Transition(transition);
    }

    IEnumerator Transitioning(SceneTransition transition)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(transition.sceneName);
        async.allowSceneActivation = false;
        yield return new WaitForSecondsRealtime(transition.transitionTime);
        async.allowSceneActivation = true;
    }

}

public struct SceneTransition
{
    public string sceneName;
    public float transitionTime;

    public SceneTransition(string _sceneName, float _transitionTime = 1f)
    {
        sceneName = _sceneName;
        transitionTime = _transitionTime;
    }
}
