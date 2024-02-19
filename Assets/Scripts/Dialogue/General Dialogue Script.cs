using System.Collections;
using System.Collections.Generic;
using System.Text;
using DialogueEditor;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralDialogueScript : MonoBehaviour
{
    private void Update()
    {
        
    }
    [SerializeField] NPCConversation conversation;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GameObject().CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !ConversationManager.Instance.IsConversationActive)
            {
                ConversationManager.Instance.StartConversation(conversation);
            }
        }
    }

}
