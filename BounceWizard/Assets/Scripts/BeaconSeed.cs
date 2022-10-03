using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconSeed : MonoBehaviour
{
    [Header("Throwing")]
    public float throwTime = 5f;
    public float throwHeight = 5f;
    public AnimationCurve throwCurve;
    public SoundSO throwSound;

    [Header("Spawning")]
    public GameObject beaconPref;

    private void Awake()
    {
        throwSound.Play(transform.position);
    }


    public void ThrowTo(Vector3 targetPos)
    {
        StartCoroutine(Throwing(transform.position, targetPos));
    }

    private IEnumerator Throwing(Vector3 startPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - startPos;
        float airTime = throwTime;
        float prog = 0f;
        float c;

        while(prog < 1f)
        {
            prog = Mathf.Min(1f, prog + Time.fixedDeltaTime/airTime);
            c = throwCurve.Evaluate(prog);
            transform.position = startPos + (offset * c) + (Vector3.up * throwHeight * Mathf.Sin(Mathf.PI * c));
            yield return new WaitForFixedUpdate();
        }
        Instantiate(beaconPref, targetPos, Quaternion.identity);
    }
}
