using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour, IPointerDownHandler
{
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;
    public Queue<string> sentences;

    private string currentSentence;

    public float typingSpeed = 0.1f;
    private bool istyping;

    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            istyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            // NPC 대화가 다 끝났으면 다음 스테이지 넘어가기
            dialoguegroup.alpha = 0;
            dialoguegroup.blocksRaycasts = false;
            SceneManager.LoadScene("Stage1-1");
        }
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        // dialogueText == currentSentence 대사 한줄 끝.
        if (dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            istyping = false;
        }
            
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!istyping) NextSentence();
    }
}
