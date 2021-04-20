using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSubtitles : MonoBehaviour
{

    public Animator animSubUp;
    public Animator animSubDown;

    public Dialogue dialogue;

    Animator triggerAnim;

    private void Start()
    {
        triggerAnim = gameObject.GetComponent<Animator>();
    }

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

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animSubUp.SetTrigger("desapear");
            triggerAnim.SetTrigger("up");
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
