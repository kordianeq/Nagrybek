using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI skinnerDialogue;
    public List<DialogueComponent> dialComp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int dialogueId = 0;

    public void DialogueTrigger()
    {
        skinnerDialogue.text = dialComp[dialogueId].dialogue;
        dialogueId++;
    }
}
