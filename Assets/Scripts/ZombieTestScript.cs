using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTestScript : MonoBehaviour
{
    Animator anim;
    //Used to check if the target has been hit
    public bool isHit = false;

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
        //If the target is hit
        if (isHit == true)
        {
            //Animate the target 
            anim.SetTrigger("hitted");

            //Set the Sound as current sound, and play it
            audioSource.GetComponent<AudioSource>().clip = Sound;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.E) && !anim.GetCurrentAnimatorStateInfo(0).IsName("punch"))
        {
            anim.SetTrigger("punch");
        }
    }
}
