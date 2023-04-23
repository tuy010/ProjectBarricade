using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public Animator anim;
    //Used to check if the target has been hit
    

    public AudioSource audioSource;

    [Header("Audio")]
    public AudioClip Sound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
