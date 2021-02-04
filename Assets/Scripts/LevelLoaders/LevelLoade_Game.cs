using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LevelLoade_Game : MonoBehaviour
{
	public Animator transition;
	public int transitionTime;

	public TMP_Dropdown resolutionDropdown;

	Resolution[] resolutions;

	public AudioMixer audioMixer;

	[SerializeField] Volume overVolume;

	LiftGammaGain liftGammaGain;

	[SerializeField] Image crossFadeImage; 

	private void Start()
    {
		crossFadeImage.color = Color.black;
		overVolume.profile.TryGet<LiftGammaGain>(out liftGammaGain);

		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width &&
			resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
		
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}

	public void OnSliGammaValue(float newValue)
    {
		//PlayerPrefs.SetFloat(gamma_PPrefsTag, newValue);
		liftGammaGain.gamma.value = Vector4.one * newValue;
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

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	public void LoadTitleScene()
    {
		Time.timeScale = 1f;
		StartCoroutine(LoadTitle());
	}
	

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(4);
	}	
	
	IEnumerator LoadTitle()
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene("Title");
	}
}