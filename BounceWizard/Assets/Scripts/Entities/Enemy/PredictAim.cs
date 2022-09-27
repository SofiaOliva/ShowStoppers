using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PredictAim
{
    private static LayerMask solidMask = LayerMask.GetMask("Wall");
    static Vector3 Predict(Vector3 startPosition, Vector3 velocity, float time)
    {
        return startPosition + velocity*time;
    }
}
