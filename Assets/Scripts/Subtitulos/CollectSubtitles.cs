using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSubtitles : MonoBehaviour
{

    public Animator animSubUp;
    public Animator animSubDown;

    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animSubUp.SetTrigger("apear");
            animSubDown.SetTrigger("Disapear");

            TriggerDialogue();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButtonDown(1))
        {
            FindObjectOfType<DialogManager>().DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
