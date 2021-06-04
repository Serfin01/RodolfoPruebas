using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Loading : MonoBehaviour
{
    public void LoadLevel (int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}