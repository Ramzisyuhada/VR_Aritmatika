using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class Percakapan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NPCConversation myConversation;

    public GameObject interactionButton; // Button yang muncul ketika mendekati penjual
    public NPCConversation conversation; // Referensi ke percakapan dari DialogueEditor
    private bool isPlayerNear = false;

    void Start()
    {
        interactionButton.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TasBelanja"))
        {
            isPlayerNear = true;
            interactionButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TasBelanja"))
        {
            isPlayerNear = false;
            interactionButton.SetActive(false);
            ConversationManager.Instance.EndConversation();
        }
    }

    public void OnButtonClick()
    {
        ShowDialog();
    }

    void ShowDialog()
    {
        interactionButton.SetActive(false);
        ConversationManager.Instance.StartConversation(conversation);
    }

}
