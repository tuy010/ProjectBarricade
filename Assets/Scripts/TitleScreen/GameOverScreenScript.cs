using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public string RestartSceneName = "OpeningCutScene";
    public string MainMenuSceneName = "TitleScreen";

    public void ClickRestart()
    {
        Debug.Log("restarts");
        SceneManager.LoadScene(RestartSceneName);
    }

    public void ClickMainMenu()
    {
        Debug.Log("mainmenu");

        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void ClickExit()
    {
        Debug.Log("exit");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
