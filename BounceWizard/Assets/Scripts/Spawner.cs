using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class Spawner : MonoBehaviour
{
    public int allyCount = 0;
    [SerializeField] Vector2 bounds;
    [SerializeField]
    GameObject enemyPref;

    [SerializeField]
    Transform player;
    [SerializeField]
    Transform enemyRoot;
    [SerializeField]
    Transform allyRoot;

    [SerializeField]
    float characterRadius;
    [SerializeField]
    LayerMask solidMask;

    public void Generate(int enemyCount)
    {
        LevelGenerator.DestroyChildren(enemyRoot);
        player.transform.position = Vector3.up * 5f;
        Physics.SyncTransforms();
        Vector3 playerPosition;
        TryFindPosition(out playerPosition);
        player.transform.position = playerPosition;

        for (int i = 0; i < enemyCount; ++i)
        {
            TrySpawn(enemyPref);          
        }
    }

    void TrySpawn(GameObject prefab)
    {
        Vector3 spawnedPosition;

        if(TryFindPosition(out spawnedPosition))
        {
            GameObject newPref = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            newPref.transform.position = spawnedPosition;
            newPref.transform.rotation = Quaternion.identity;
            newPref.transform.SetParent(enemyRoot);
        }
        else
        {
            Debug.LogError("Could not find spawnpoint for enemy!");
        }        
    }

    bool TryFindPosition(out Vector3 spawnedPosition)
    {
        int maxTries = 10;
        int tries = 0;

        while (true)
        {
            spawnedPosition = new Vector3(Random.Range(-1f, 1f)*bounds.x, 0f, Random.Range(-1f, 1f)*bounds.y);
            tries++;
            if (tries > maxTries)
            {
                Debug.LogError("Could not find spawnpoint for enemy!");
                return false;
            }
            if (!CollisionsAt(spawnedPosition))
            {
                return true;
            }
        }
    }

    bool CollisionsAt(Vector3 p)
    {
        Collider[] colliders = Physics.OverlapSphere(p, characterRadius, solidMask);
        return colliders.Length > 0;
    }
}
