using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCaller : MonoBehaviour
{
    public string sceneName;
    public float duration;
    public EventSO_SceneTransition transitionEvent;

    public void Transition()
    {
        transitionEvent.Trigger(new SceneTransition(sceneName, duration));
    }
}
