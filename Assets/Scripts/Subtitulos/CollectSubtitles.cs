using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSubtitles : MonoBehaviour
{

    public Animator animSubUp;
    public Animator animSubDown;

    public Dialogue dialogue;

    Animator triggerAnim;
    DialogManager dialogManager;

    private void Start()
    {
        triggerAnim = gameObject.GetComponent<Animator>();
        //Debug.Log("*** CollectSubtitles.Start: in objecte" + gameObject.name + " found animator " + triggerAnim);
        dialogManager = GetComponent<DialogManager>();
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
            //FindObjectOfType<DialogManager>().DisplayNextSentence();
            dialogManager.DisplayNextSentence();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animSubUp.SetTrigger("desapear");
            triggerAnim.SetTrigger("up");
            //Debug.Log("*** CollectSubtitles.OnTriggerExit: in objecte" + gameObject.name + " found animator " + triggerAnim);
        }
    }

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        dialogManager.StartDialogue(dialogue);
    }
}
