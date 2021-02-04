using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{
    public AudioSource myfx;
    public AudioClip hoverFx;
    public AudioClip clickFx;


    public void HoverSound()
    {
        myfx.PlayOneShot(hoverFx);
    }
    
    public void ClickSound()
    {
        myfx.PlayOneShot(clickFx);
    }

}
