﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Creditos : MonoBehaviour
{
	public Animator transition;

	public float transitionTime = 1f;

    private void Update()
    {
		if (Input.GetButtonDown("Fire1"))
        {
			GoToMenu();
        }
    }

    public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(1);
	}

	public void GoToMenu()
    {
		LoadNextLevel();
	}

}