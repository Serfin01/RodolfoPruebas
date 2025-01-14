﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : MonoBehaviour
{

    //public Text nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public Animator animSubUp;
    Animator triggerAnim;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        triggerAnim = gameObject.GetComponent<Animator>();
        //Debug.Log("*** DialogManager.Start: in objecte" + gameObject.name + " used animator " + triggerAnim);

    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Start Conver with" + dialogue.name);

        //nameText.text = dialogue.name

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sencence = sentences.Dequeue();
        dialogueText.text = sencence;
    }

    public void EndDialogue()
    {
        //Debug.Log("End conver");
        animSubUp.SetTrigger("desapear");
        triggerAnim.SetTrigger("up");
        //Debug.Log("*** DialogManager.EndDialog: in objecte" + gameObject.name + " used animator " + triggerAnim);
    }
}
