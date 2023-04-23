using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public string RestartSceneName = "OpeningCutScene";
    public string MainMenuSceneName = "TitleScreen";

    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickRestart()
    {
        Debug.Log("restarts");
        audioSource.Play();
        SceneManager.LoadScene(RestartSceneName);
    }

    public void ClickMainMenu()
    {
        Debug.Log("mainmenu");
        audioSource.Play();

        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void ClickExit()
    {
        Debug.Log("exit");
        audioSource.Play();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
