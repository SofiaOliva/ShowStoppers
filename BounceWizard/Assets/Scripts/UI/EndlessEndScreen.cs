using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEndScreen : LevelEndScreen
{
    public override string GetMessage(LevelResults results)
    {
        string answer = base.GetMessage(results);
        answer += "\n";
        answer += "You survived " + results.gameData.level + " rounds";
        return answer;
    }
}
