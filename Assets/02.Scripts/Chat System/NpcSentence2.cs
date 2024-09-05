using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentence2 : MonoBehaviour
{
    public string[] Sentences;
    public GameObject RemoveTarget1;
    public GameObject RemoveTarget2;
    private void OnMouseDown()
    {
        if(DialogueManager.instance.dialoguegroup.alpha == 0)
        {
            DialogueManager.instance.Ondialogue(Sentences);
            RemoveTarget1.SetActive(false);
            RemoveTarget2.SetActive(false);
        }
    }
}
