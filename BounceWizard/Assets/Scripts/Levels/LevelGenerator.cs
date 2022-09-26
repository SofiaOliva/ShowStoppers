using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class LevelGenerator : MonoBehaviour
{
    public LevelSO levelSO;
    public bool generate = false;
    public Transform mapParent;

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
        GenerateWithSeed(levelSO);
    }

    void GenerateWithSeed(LevelSO level)
    {
        int seed = level.Seed;
        Random.State oldState = Random.state;
        Random.InitState(seed);

        Generate(level);

        Random.state = oldState;
    }

    void Generate(LevelSO level)
    {
        GenerateMap(level);
        Physics.SyncTransforms(); //so enemies dont spawn in new walls
        GetComponentInChildren<Spawner>().Generate(level.enemyCount);
    }

    void GenerateMap(LevelSO level)
    {
        DestroyChildren(mapParent);
        GameObject map = (GameObject)PrefabUtility.InstantiatePrefab(level.mapList.GetRandomMap());
        map.transform.position = Vector3.zero;
        map.transform.SetParent(mapParent);
        Vector2 flipXZ = new Vector2(Random.Range(0, 2) == 0 ? 1f : -1f, Random.Range(0, 2) == 0 ? 1f : -1f);
        map.transform.localScale = new Vector3(flipXZ.x, 1f, flipXZ.y);
    }

    public static void DestroyChildren(Transform parent)
    {
        for (int i = parent.childCount; i > 0; --i)
        {
            DestroySafe(parent.GetChild(0).gameObject);
        }
    }

    public static void DestroySafe(GameObject go)
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
