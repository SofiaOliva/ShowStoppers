using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeakerSO", menuName = "SO/Dialogue/SpeakerSO")]
public class SpeakerSO : ScriptableObject
{
    public string speakerName;
    public Font font;
    public Color fontColor;
}
