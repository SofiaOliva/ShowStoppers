using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public EventSO<Shake> shakeEvent;

    public float maxOffset = 5f;
    public AnimationCurve shakeDecay;

    private List<Shake> shakes;

    private void OnEnable()
    {
        shakeEvent.Event += Shake;
        shakes = new List<Shake>();
        StartCoroutine(Shaking());
    }

    private void OnDisable()
    {
        shakeEvent.Event -= Shake;
    }

    void Shake(Shake shake)
    {
        shakes.Add(shake);
    }

    IEnumerator Shaking()
    {
        float magnitude;
        Vector2 offset;
        while (true)
        {
            magnitude = 0f;
            for(int i = shakes.Count-1; i >= 0; --i)
            {
                Shake shake = shakes[i];
                shake.prog += Time.deltaTime / shake.duration;
                magnitude += shakeDecay.Evaluate(1f - shake.prog) * shake.magnitude;
                if(shake.duration <= 0f)
                {
                    shakes.RemoveAt(i);
                }
            }
            offset = Random.insideUnitCircle.normalized * Mathf.Min(magnitude, maxOffset);
            transform.localPosition = new Vector3(offset.x, 0f, offset.y);
            yield return null;
        }
    }
}

