using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jailConvoStart : MonoBehaviour
{
    [SerializeField] private NPCConversation conversation;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ConversationManager.Instance.StartConversation(conversation);
        }
    }
}
