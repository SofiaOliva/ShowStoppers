using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
    //public EventSO_SceneTransition transitionEvent;
    //Image wipeImage;
    Material wipeMaterial;
    public AnimationCurve wipeCurve;

    private void OnEnable()
    {
        //wipeImage = GetComponentInChildren<Image>();
        wipeMaterial = GetComponentInChildren<Image>().material;
        ResetShader(true);
        StartCoroutine(Transitioning(true, 0.5f));
        //transitionEvent.Event += Transition;
    }

    private void OnDisable()
    {
        //transitionEvent.Event -= Transition;
        ResetShader(false);
    }

    void ResetShader(bool dark)
    {
        wipeMaterial.SetFloat("_TransIn", dark ? 0f : 1f);
        wipeMaterial.SetFloat("_TransOut", 0f);
    }

    public void Transition(SceneTransition transition)
    {
        StartCoroutine(Transitioning(false, transition.transitionTime));
    }

    IEnumerator Transitioning(bool transIn, float time)
    {
        float prog = 0f;
        while (prog < 1f) {
            prog = Mathf.Min(1f, prog + Time.deltaTime/time);
            wipeMaterial.SetFloat(transIn ? "_TransIn" : "_TransOut", wipeCurve.Evaluate(prog));
            yield return null;
        }
        
    }
}
