using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPool : MonoBehaviour
{
    public ManaPoolSO manaPool;

    private void Start()
    {
        foreach (ManaStreamSO stream in manaPool.allStreams)
        {
            stream.Reset();
        }
    }

    private void FixedUpdate()
    {
        foreach(ManaStreamSO stream in manaPool.streams)
        {
            stream.Fill(Time.fixedDeltaTime);
        }
    }

    public bool TryCast(int index)
    {
        return manaPool.streams[index].TryCast();
    }
}
