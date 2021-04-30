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
    public float transitionTime;

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
    }

    List<int> widths = new List<int>() { 540, 1280, 1920 };
    List<int> heights = new List<int>() { 960, 720, 1080 };

    public void SetResolution(int index)
    {
        bool fullscreen = Screen.fullScreen;

        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
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