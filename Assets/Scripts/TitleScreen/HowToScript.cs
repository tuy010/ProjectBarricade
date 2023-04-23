using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToScript : MonoBehaviour
{
    public GameObject howToScreen;
    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickX()
    {
        howToScreen = GameObject.Find("Canvas2");
        audioSource.Play();
        howToScreen.SetActive(false);
    }
}
