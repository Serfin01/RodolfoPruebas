using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Ending : MonoBehaviour
{
	public Animator transition;

	public float transitionTime = 1f;


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
	
	public void LoadRetryLevel()
	{
		StartCoroutine(LoadLevel1());
	}

	IEnumerator LoadLevel1()
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(2);
	}

	public void GoToMenu()
    {
		LoadNextLevel();
	}
	
	public void Retry()
    {
		LoadRetryLevel();
	}

}