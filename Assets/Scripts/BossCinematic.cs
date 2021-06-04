using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class BossCinematic : MonoBehaviour
{
    public GameObject cam1;
    public GameObject videoobj;

    public VideoPlayer video;

    void Start()
    {

        video.loopPointReached += EndReached;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            videoobj.SetActive(true);
            cam1.SetActive(false);
            Debug.Log("videoPlays");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Time.timeScale = 1f;
                cam1.SetActive(true);
                videoobj.SetActive(false);
                Debug.Log("videoEnds");
                Destroy(this);
            }
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Time.timeScale = 1f;
                cam1.SetActive(true);
                videoobj.SetActive(false);
                Debug.Log("videoEnds");
                Destroy(this);
            }
        }

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Time.timeScale = 1f;
        cam1.SetActive(true);
        videoobj.SetActive(false);
        Debug.Log("videoEnds");
        Destroy(this);
    }

}
