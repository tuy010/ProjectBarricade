using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    #region FIELD SERIALIZED
    [Title("Status")]
    [SerializeField]
    private float hp;
    private bool isActive;

    [Title("Audio")]
    [SerializeField]
    private AudioSource audioSource;

    [Title("AudioClip")]
    [SerializeField]
    private AudioClip[] hittedSounds;
    [SerializeField]
    private AudioClip[] crashedSounds;
    #endregion

    [Title("etc")]
    [SerializeField]
    private Transform[] barricades;
    [SerializeField]
    private GameObject dustParticle;

    private void Start()
    {
        //barricades = gameObject.GetComponentsInChildren<Transform>();
        isActive = true;
    }

    #region METHODS
    public void GetDmg(float dmg)
    {
        hp-=dmg;
        if (hp <= 0 && isActive)
        {
            isActive = false;
            playSound(1);
            foreach(var bc in barricades)
                Destroy(bc.gameObject);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(Instantiate(dustParticle, gameObject.transform.position, Quaternion.identity), 1f);
            Destroy(gameObject, 3f);           
        }
        else
        {
            playSound(0);
        }
    }

    private void playSound(int type)
    {
        AudioClip[] clips = null;
        switch (type)
        {
            case 0:
                clips = hittedSounds;
                break;
            case 1:
                clips = crashedSounds;
                break;
        }
        AudioClip ac = clips[Random.Range(0, clips.Length)];
        audioSource.clip = ac;
        audioSource.Play();
    }
    #endregion
}
