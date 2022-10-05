using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ManaPool")]
public class ManaPoolSO : ScriptableObject
{
    public ManaStreamSO[] streams;

    public ManaStreamSO[] allStreams;

    public void UnlockStreams(int index)
    {
        index = Mathf.Clamp(index, 0, 2);
        streams = new ManaStreamSO[index+1];
        for (int i = 0; i <= index; ++i)
        {
            streams[i] = allStreams[i];
        }
        for(int i = index+1; i <= 2; ++i)
        {
            allStreams[i].Reset();
        }
    }
}
