using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string sceneName= "OpeningCutScene";
    public GameObject howToScreen;

    AudioSource audioSource;

    // Start is called before the first frame update
    public void Start()
    {
        howToScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }


    public void ClickStart()
    {
        Debug.Log("시작");
        SceneManager.LoadScene(sceneName);
        audioSource.Play();

    }

    public void ClickHowTo()
    {
        Debug.Log("조작방법");
        
        howToScreen.SetActive(true);
        audioSource.Play();
    }

    public void ClickExit()
    {
        Debug.Log("종료");
        audioSource.Play();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
