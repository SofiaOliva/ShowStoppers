using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPool : MonoBehaviour
{
    public ManaStream[] manaStreams;

    private void FixedUpdate()
    {
        foreach(ManaStream stream in manaStreams)
        {
            stream.Fill(Time.fixedDeltaTime);
        }
    }

    public bool TryCast(int index)
    {
        return manaStreams[index].TryCast();
    }
}
