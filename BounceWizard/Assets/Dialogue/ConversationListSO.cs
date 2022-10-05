using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Dialogue/ConversationList")]
public class ConversationListSO : ScriptableObject
{
    public ConversationSO[] conversations;

    public ConversationSO this[int i]
    {
        get { return conversations[i]; }
    }
}
