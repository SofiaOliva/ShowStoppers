using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPool : MonoBehaviour
{
    public ManaStreamSO[] manaStreams;

    private void Start()
    {
        foreach (ManaStreamSO stream in manaStreams)
        {
            stream.Start();
        }
    }

    private void FixedUpdate()
    {
        foreach(ManaStreamSO stream in manaStreams)
        {
            stream.Fill(Time.fixedDeltaTime);
        }
    }

    public bool TryCast(int index)
    {
        return manaStreams[index].TryCast();
    }
}
