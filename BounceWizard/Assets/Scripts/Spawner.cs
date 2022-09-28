using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class Spawner : MonoBehaviour
{
    [SerializeField] Vector2 bounds;
    [SerializeField]
    GameObject enemyPref, allyPref;

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

    public void Generate(Level level)
    {
        LevelGenerator.DestroyChildren(enemyRoot);
        LevelGenerator.DestroyChildren(allyRoot);
        player.transform.position = Vector3.up * 5f;
        Physics.SyncTransforms();
        Vector3 playerPosition;
        TryFindPosition(out playerPosition);
        player.transform.position = playerPosition;

        for (int i = 0; i < level.allyCount; ++i)
        {
            TrySpawn(allyPref, allyRoot);
        }

        for (int i = 0; i < level.enemyCount; ++i)
        {
            TrySpawn(enemyPref, enemyRoot);          
        }
    }

    void TrySpawn(GameObject prefab, Transform parent)
    {
        Vector3 spawnedPosition;

        if(TryFindPosition(out spawnedPosition))
        {
            GameObject newPref = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            newPref.transform.position = spawnedPosition;
            newPref.transform.rotation = Quaternion.identity;
            newPref.transform.SetParent(parent);
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
