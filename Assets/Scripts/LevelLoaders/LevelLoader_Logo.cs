using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Logo : MonoBehaviour
{
	public Animator transition;
	public Animator logoAnim;

	public float transitionTime = 1f;


	void Update()
	{
		LoadNextLevel2();

		if (Input.GetMouseButtonDown(0))
		{
			LoadNextLevel();
		}
	}

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}
	
	public void LoadNextLevel2()
	{
		StartCoroutine(LoadLevel2(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(levelIndex);
	}
		
	IEnumerator LoadLevel2(int levelIndex)
	{
		logoAnim.SetTrigger("logoanim");

		yield return new WaitForSeconds(7);

		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(levelIndex);
	}

}