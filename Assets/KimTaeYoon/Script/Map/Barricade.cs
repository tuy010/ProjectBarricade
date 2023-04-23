using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barricade : MonoBehaviour
{
    #region FIELD SERIALIZED
    [Title("Status")]
    [SerializeField]
    private float maxHp;
    [SerializeField]
    private float hp;

    private bool isActive;

    [Title("UI")]
    [SerializeField]
    private GameObject hpUIPrefab;

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
    private TurnSys turnSys;
    [SerializeField]
    private Transform[] barricades;
    [SerializeField]
    private GameObject dustParticle;

    private GameObject hpUIobj;
    
    #region UNITY
    private void Start()
    {
        //barricades = gameObject.GetComponentsInChildren<Transform>();
        isActive = true;
        if (turnSys == null)
            turnSys = GameObject.FindGameObjectWithTag("Sys").GetComponent<TurnSys>();
        hp = maxHp;

        hpUIobj = Instantiate(hpUIPrefab);

        hpUIobj.GetComponent<BarricadeHpUI>().InitUI(this);
    }
    #endregion

    public float GetMaxHp() => maxHp;
    public float GetHp() => hp;

    #region METHODS
    public void GetDmg(float dmg)
    {
        hp-=dmg;
        if (hp <= 0 && isActive)
        {
            isActive = false;
            turnSys.EndGame(this.transform.position);
            playSound(1);
            Destroy(hpUIobj);

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
