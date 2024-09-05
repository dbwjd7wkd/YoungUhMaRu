using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentence : MonoBehaviour
{
    public string[] sentences;
    public Transform chatTr;
    public GameObject chatBoxPrefab; // => ChatSystem.cs
    public static GameObject go;

    private void Start()
    {
        Invoke("TalkNpc", 1f);
    }

    public void TalkNpc()
    {
        go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().Ondialogue(sentences, chatTr);
        Invoke("TalkNpc", 8f);
    }

}
