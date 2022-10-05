using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceHeight = 5f;
    public float bouncePeriod = 4f;

    private void Start()
    {
        StartCoroutine(Bouncing());
    }
    IEnumerator Bouncing()
    {
        Vector2 startPos = transform.position;
        while (true)
        {
            transform.position = startPos + Vector2.up * Mathf.Abs(bounceHeight * Mathf.Sin(2f*Mathf.PI*Time.unscaledTime/bouncePeriod));
            yield return null;
        }
    }
}
