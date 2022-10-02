using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconSeed : MonoBehaviour
{
    [Header("Throwing")]
    [Tooltip("Units per second")]
    public float throwSpeed = 5f;
    public float throwHeight = 5f;
    public AnimationCurve throwCurve;

    [Header("Spawning")]
    public GameObject beaconPref;


    public void ThrowTo(Vector3 targetPos)
    {
        StartCoroutine(Throwing(transform.position, targetPos));
    }

    private IEnumerator Throwing(Vector3 startPos, Vector3 targetPos)
    {
        Vector3 offset = targetPos - startPos;
        float airTime = offset.magnitude / throwSpeed;
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
