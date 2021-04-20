using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LevelLoader_Title : MonoBehaviour
{
	public Animator transition;

	public AudioMixer audioMixer;

	public float transitionTime = 1f;

	public TMP_Dropdown resolutionDropdown;

	Resolution[] resolutions;

	[SerializeField] Volume overVolume;

	LiftGammaGain liftGammaGain;

	void Start()
    {
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for(int i = 0; i < resolutions.Length; i++)
        {
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);

			if(resolutions[i].width == Screen.currentResolution.width &&
			resolutions[i].height == Screen.currentResolution.height)
            {
				currentResolutionIndex = i;
			}
        }

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
		overVolume.profile.TryGet<LiftGammaGain>(out liftGammaGain);
	}

	public void SetResolution (int resolutionIndex)
    {
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(levelIndex);
	}
	

	public void PlayGame()	
    {
		LoadNextLevel();

	}	
	
	public void QuitGame()
    {
		Debug.Log("quitGame");
		Application.Quit();

	}

	public void SetMasterVolume(float volume)
    {
		audioMixer.SetFloat("volume", volume);

	}

	public void SetMusicVolume(float volume)
    {
		audioMixer.SetFloat("Music", volume);

	}

	public void SetSfxVolume(float volume)
    {
		audioMixer.SetFloat("Sfx", volume);

    }

	public void SetQuality(int qualityIndex)
    {
		QualitySettings.SetQualityLevel(qualityIndex); 
    }

	public void SetFullscreen (bool isFullscreen)
    {
		Screen.fullScreen = isFullscreen;
	}

	public void OnSliGammaValue(float newValue)
	{
		//PlayerPrefs.SetFloat(gamma_PPrefsTag, newValue);
		liftGammaGain.gamma.value = Vector4.one * newValue;
	}

}