using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public ConversationListSO conversations;
    public GameDataSO gameData;

    public TMP_Text nameText;
    public TMP_Text contentText;

    public EventSO_SceneTransition transitionEvent;

    private void Start()
    {
        if(gameData.Level >= conversations.conversations.Length)
        {
            transitionEvent.Trigger(new SceneTransition("Game", 0.01f));
        }
        PlayConversation(conversations[gameData.Level]);
    }

    private void PlayConversation(ConversationSO convo)
    {
        StartCoroutine(PlayingConversation(convo));
    }

    void SetConvoLine(ConversationSO convo, int line)
    {
        nameText.text = convo.defaultSpeaker.speakerName;
        contentText.text = convo.lines[line].text;
    }

    private IEnumerator PlayingConversation(ConversationSO convo)
    {
        int page = 0;
        SetConvoLine(convo, 0);
        while (true)
        {
            if (Input.anyKeyDown)
            {
                ++page;
                if (page >= convo.lines.Length) break;
                SetConvoLine(convo, page);
            }
            yield return null;
        }
        if (!gameData.HasFinished())
        {
            transitionEvent.Trigger(new SceneTransition("Game", 1f));
        }
        else
        {
            transitionEvent.Trigger(new SceneTransition("Menu", 2.5f));
        }
    }
}
