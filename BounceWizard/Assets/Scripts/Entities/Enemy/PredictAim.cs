using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PredictAim
{
    private static LayerMask solidMask = LayerMask.GetMask("Wall");

    public static bool TryAim(Rigidbody thrower, Rigidbody[] targets, out Vector3 aimDirection, float projectileSpeed, float castTime)
    {
        float bestShotWeight = float.MaxValue;
        Vector3 bestShotDirection = Vector3.forward;

        foreach (Rigidbody target in targets)
        {
            Vector3 throwerPosWhenThrow = Predict(thrower.position, thrower.velocity, castTime);
            Vector3 targetPosWhenHit;
            for (float hitTime = castTime + 0.5f; hitTime <= 5f; hitTime += 0.5f)
            {
                targetPosWhenHit = Predict(target.position, target.velocity, hitTime);

                if (!LOS(throwerPosWhenThrow, targetPosWhenHit)) continue;

                Vector3 projectilePath = targetPosWhenHit - throwerPosWhenThrow;

                float projectileActualDistance = projectileSpeed * (hitTime - castTime);
                float projectileExpectedDistance = (projectilePath).magnitude;

                float aimWeight = Mathf.Abs(projectileActualDistance - projectileExpectedDistance);
                if(aimWeight < bestShotWeight)
                {
                    bestShotDirection = projectilePath.normalized;
                    bestShotWeight = aimWeight;
                }
            }
        }

        aimDirection = bestShotDirection;
        return bestShotWeight < 5f;
    }

    static Vector3 Predict(Vector3 startPosition, Vector3 velocity, float time)
    {
        return startPosition + velocity*time;
    }

    static bool LOS(Vector3 v1, Vector3 v2)
    {
        return !Physics.Raycast(v1, v2 - v1, Vector3.Distance(v1,v2), solidMask);
    }
}

//public class AimTarget
//{
//    public Vector3 direction = Vector3.forward;
//    public float weight = 1f;

//    public AimTarget(Vector3 _direction, float _weight)
//    {
//        direction = _direction;
//        weight = _weight;
//    }

//    public float Weight
//    {
//        get
//        {
//            return weight;
//        }
//    }

//    public static float CalcWeight(float distance)
//    {
//        return distance;
//    }
//}