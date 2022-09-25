using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class Spawner : MonoBehaviour
{
    public int seed = 0;
    public int enemyCount = 4;
    public int allyCount = 0;
    [SerializeField] Vector2 bounds;
    public bool generate = false;
    [SerializeField]
    GameObject enemyPref;

    [SerializeField]
    Transform enemyRoot;
    [SerializeField]
    Transform allyRoot;

    [SerializeField]
    float characterRadius;
    [SerializeField]
    LayerMask solidMask;

    private void OnValidate()
    {
        if (generate)
        {
            generate = false;
            StartCoroutine(GenerateNextFrame());
        }
    }

    IEnumerator GenerateNextFrame()
    {
        yield return null;
        Generate();
    }

    void Generate()
    {
        Random.State oldState = Random.state;
        Random.InitState(seed);
        for (int i = enemyRoot.childCount; i > 0; --i)
        {
            DestroySafe(enemyRoot.GetChild(0).gameObject);
        }

        Vector3 spawnedPosition;
        int maxTries = 10;
        int tries;
        Vector3 bounds3 = new Vector3(bounds.x, 0f, bounds.y);
        for (int i = 0; i < enemyCount; ++i)
        {
            tries = 0;
            while (true)
            {
                spawnedPosition = Vector3.Scale(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)), bounds3);
                //Debug.Log("Try spawn at " + spawnedPosition);
                tries++;
                if (tries > maxTries)
                {
                    Debug.LogError("Could not find spawnpoint for enemy!");
                    break;
                }
                if (!CollisionsAt(spawnedPosition))
                {
                    GameObject newEnemy = (GameObject)PrefabUtility.InstantiatePrefab(enemyPref);
                    newEnemy.transform.position = spawnedPosition;
                    newEnemy.transform.rotation = Quaternion.identity;
                    newEnemy.transform.SetParent(enemyRoot);
                    break;
                }
            }            
        }

        Random.state = oldState;
    }

    bool CollisionsAt(Vector3 p)
    {
        Collider[] colliders = Physics.OverlapSphere(p, characterRadius, solidMask);
        return colliders.Length > 0;
    }

    void DestroySafe(GameObject go)
    {
        if (Application.isEditor)
        {
            DestroyImmediate(go);
        }
        else
        {
            Destroy(go);
        }
    }
}
