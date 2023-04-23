using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLineScript : MonoBehaviour
{
    public string sceneName = "GamePlay";
    void OnEnable()
    {
        Debug.Log("111");
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(sceneName);
        Debug.Log("222");
    }
}
