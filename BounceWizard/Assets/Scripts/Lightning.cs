using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public RuntimeSet_Entity allySet;

    public GameObject lightningEffect;
    [SerializeField] SoundSO thunderSound;
    [SerializeField] ManaPoolSO manaPool;
    [SerializeField]
    ShakeSO shake;

    List<ManaStreamSO> subbedStreams;

    public void Awake()
    {
        subbedStreams = new List<ManaStreamSO>();
    }

    void OnEnable()
    {
        if (!manaPool) return;
        foreach(ManaStreamSO stream in manaPool.streams)
        {
            stream.Explode += Strike;
            subbedStreams.Add(stream);
        }
    }

    void OnDisable()
    {
        foreach(ManaStreamSO stream in subbedStreams)
        {
            stream.Explode -= Strike;
        }
        subbedStreams.Clear();
    }

    private void Strike()
    {
        if (allySet.Count == 0) return;

        Entity struckEntity = allySet[Random.Range(0, allySet.Count)];
        thunderSound.Play(transform.position);
        GameObject spawnedBolt = Instantiate(lightningEffect, struckEntity.transform.position, Quaternion.identity);
        Destroy(spawnedBolt, 0.25f);
        shake.DoShake();
        struckEntity.TakeDamage(2);
    }
}
