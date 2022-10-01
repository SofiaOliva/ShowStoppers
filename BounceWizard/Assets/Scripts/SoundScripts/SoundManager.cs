using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //this pair is called whenever playing a directionless oneshot
    private static GameObject oneShotOb;
    private static AudioSource oneShotAudS;

    public static SoundManager _instance;

    public static SoundManager sm
    {
        get
        {
            if (_instance == null)
            {
                var s = new GameObject("SoundManager");
                _instance = s.AddComponent<SoundManager>();
            }
            return _instance;
        }
    }

    public static void PlayOneShot(SoundSO sound, float volume = 1f)
    {
        if (oneShotOb == null)
        {
            //oneShotOb = new GameObject("OneShotSound");
            //oneShotAudS = oneShotOb.AddComponent<AudioSource>();
            GetSoundObject(out oneShotOb, out oneShotAudS);
        }

        oneShotAudS.PlayOneShot(sound.Clip, volume * sound.Volume);
    }

    static void GetSoundObject(out GameObject ob, out AudioSource source)
    {
        ob = Instantiate((GameObject)Resources.Load("DefaultAudioSource"));
        source = ob.GetComponent<AudioSource>();
        ob.name = "Sound";
    }

    public static AudioSource Play(SoundSO sound, Vector3 position)
    {
        if (!sound) return null;
        GameObject soundOb;
        AudioSource source;
        GetSoundObject(out soundOb, out source);
        soundOb.transform.position = position;
        
        
        soundOb.transform.SetParent(sm.transform);
        source.clip = sound.Clip;
        source.volume = sound.Volume;
        source.pitch = Random.Range(sound.pitchRange.x, sound.pitchRange.y);
        source.spatialBlend = sound.spatialBlend;

        source.Play();

        sm.StartCoroutine(destroyIn(soundOb, source.clip.length));

        return source;
    }

    private static IEnumerator destroyIn(GameObject go, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Object.Destroy(go);
        yield return null;
    }
}
