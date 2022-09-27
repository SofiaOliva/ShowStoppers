using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Transform enemyRoot;
    public Transform allyRoot;

    public GameObject lightningEffect;
    ManaPool manaPool;
    [SerializeField]
    ShakeSO shake;

    public void Awake()
    {
        manaPool = FindObjectOfType<ManaPool>();
    }

    private void OnEnable()
    {
        if (!manaPool) return;
        foreach(ManaStreamSO stream in manaPool.manaStreams)
        {
            stream.Explode += Strike;
        }
    }

    private void OnDisable()
    {
        if (!manaPool) return;
        foreach (ManaStreamSO stream in manaPool.manaStreams)
        {
            stream.Explode -= Strike;
        }
    }

    private void Strike()
    {
        int allyCount = allyRoot.childCount;
        if (allyCount == 0) return;
        Entity struckEntity = allyRoot.GetChild(Random.Range(0, allyCount)).gameObject.GetComponent<Entity>();
        GameObject spawnedBolt = Instantiate(lightningEffect, struckEntity.transform.position, Quaternion.identity);
        Destroy(spawnedBolt, 0.25f);
        shake.DoShake();
        struckEntity.TakeDamage(2);
    }
}
