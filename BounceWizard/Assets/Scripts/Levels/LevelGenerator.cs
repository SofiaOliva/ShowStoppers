using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class LevelGenerator : MonoBehaviour
{
    public LevelSO levelSO;
    public Transform mapParent;
    public bool generateButton = false;

    private void OnValidate()
    {
        if (generateButton)
        {
            generateButton = false;
            StartCoroutine(GenerateNextFrame());
        }
    }

    IEnumerator GenerateNextFrame()
    {
        yield return null;
        Generate(levelSO.level);
    }

    public void Generate(Level level)
    {
        int seed = level.Seed;
        Random.State oldState = Random.state;
        Random.InitState(seed);

        GenerateSeedless(level);

        Random.state = oldState;
    }

    void GenerateSeedless(Level level)
    {
        GenerateMap(level);
        Physics.SyncTransforms(); //so enemies dont spawn in new walls
        GetComponentInChildren<Spawner>().Generate(level);
    }

    void GenerateMap(Level level)
    {
        DestroyChildren(mapParent);
        GameObject map;
        GameObject mapPrefab = level.GetMap();
#if UNITY_EDITOR
        map = (GameObject)PrefabUtility.InstantiatePrefab(mapPrefab);
#else
        map = Instantiate(mapPrefab);
#endif
        map.transform.position = Vector3.zero;
        map.transform.SetParent(mapParent);
        Vector2 flipXZ = new Vector2(Random.Range(0, 2) == 0 ? 1f : -1f, Random.Range(0, 2) == 0 ? 1f : -1f);
        map.transform.localScale = new Vector3(flipXZ.x, 1f, flipXZ.y);
    }

    public static void DestroyChildren(Transform parent)
    {
        for (int i = parent.childCount-1; i >= 0; --i)
        {
            DestroySafe(parent.GetChild(i).gameObject);
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
