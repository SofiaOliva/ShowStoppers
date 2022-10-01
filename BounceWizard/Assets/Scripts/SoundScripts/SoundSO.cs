using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoundSO", menuName = "SO/Sound/Sound", order = 1)]
public class SoundSO : ScriptableObject
{
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    float volume = 1f;
    [Range(0f, 1f)]
    public float spatialBlend = 1f;

    public Vector2 pitchRange = new Vector2(1f, 1f);

    public AudioClip Clip
    {
        get
        {
            return clips[Random.Range(0, clips.Length - 1)];
        }
    }
    public float Volume
    {
        get
        {
            return volume;
        }
    }

    public void Play(Vector3 position)
    {
        SoundManager.Play(this, position);
    }
}
