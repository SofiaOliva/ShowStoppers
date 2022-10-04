using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreText : MonoBehaviour
{
    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        if (PlayerPrefs.HasKey("highscore"))
        {
            text.text = "Best: " + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            text.text = "";
        }
        
    }
}
