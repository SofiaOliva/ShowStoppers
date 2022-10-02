using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEndScreen : MonoBehaviour
{
    public TMP_Text messageText;

    public void SetResults(LevelResults results)
    {
        if(messageText) messageText.text = GetMessage(results);
    }

    public virtual string GetMessage(LevelResults results)
    {
        return results.message;
    }
}
