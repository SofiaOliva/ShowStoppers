using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Transform enemyRoot;

    public GameObject lightningEffect;
    ManaPool manaPool;

    public void Awake()
    {
        manaPool = FindObjectOfType<ManaPool>();
    }

    private void OnEnable()
    {
        foreach(ManaStream stream in manaPool.manaStreams)
        {
            stream.Explode += Strike;
        }
    }

    private void OnDisable()
    {
        foreach (ManaStream stream in manaPool.manaStreams)
        {
            stream.Explode -= Strike;
        }
    }

    private void Strike()
    {
        int enemyCount = enemyRoot.childCount;
        Entity struckEntity = enemyRoot.GetChild(Random.Range(0, enemyCount)).gameObject.GetComponent<Entity>();
        GameObject spawnedBolt = Instantiate(lightningEffect, struckEntity.transform.position, Quaternion.identity);
        Destroy(spawnedBolt, 0.25f);
        struckEntity.TakeDamage(2);
    }
}
