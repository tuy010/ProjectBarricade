using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToScript : MonoBehaviour
{
    public GameObject howToScreen;
    public void ClickX()
    {
        howToScreen = GameObject.Find("Canvas2");
        howToScreen.SetActive(false);
    }
}
