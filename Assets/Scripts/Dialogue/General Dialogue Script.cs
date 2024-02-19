using System.Collections;
using System.Collections.Generic;
using System.Text;
using DialogueEditor;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralDialogueScript : MonoBehaviour
{
    [SerializeField] NPCConversation conversation;
    private void OnEnable()
    {
        ConversationManager.OnConversationEnded += ConversationEnd;
    }

    private void OnDisable()
    {
        ConversationManager.OnConversationEnded -= ConversationEnd;
    }

    void ConversationEnd()
    {
        Destroy(conversation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().CompareTag("Player"))
        {
            ConversationManager.Instance.StartConversation(conversation);
        }
    }

}
