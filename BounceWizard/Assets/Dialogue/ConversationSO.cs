using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Conversation", menuName = "SO/Dialogue/Conversation", order = 1)]
public class ConversationSO : ScriptableObject
{
    public SpeakerSO defaultSpeaker;
    public TextAsset textAsset;
    public ConvoLine[] lines;
    //public EventSO[] eventsOnCompletion; //events that are fired after all lines have been spoken
    public ConversationSO nextConvo; //conversation that plays immediately after this one

    public void OnValidate()
    {
        if (textAsset != null)
        {
            string[] fileLines = textAsset.text.Split('\n');
            lines = new ConvoLine[fileLines.Length - 1];
            for (int i = 0; i < lines.Length; ++i)
            {
                lines[i].text = fileLines[i];
            }
        }
    }
}

[System.Serializable]
public struct ConvoLine
{
    public SpeakerSO speaker;
    [TextArea(3, 10)]
    public string text;
}