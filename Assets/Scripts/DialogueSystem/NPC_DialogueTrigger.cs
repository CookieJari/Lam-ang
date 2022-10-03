using UnityEngine;

public class NPC_DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}