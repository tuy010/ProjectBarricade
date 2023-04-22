using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreAndItem : MonoBehaviour
{
    #region FIELD SERIALIZED
    [Title("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float score;

    [Title("Player")]
    [SerializeField] private Character characterBehaviour;
    [SerializeField] private WeaponBehaviour assaultRifle;
    [SerializeField] private WeaponBehaviour shotGun;
    [SerializeField] private WeaponBehaviour sniper;

    [Title("Drop Chance")]
    [SerializeField] private int grenadeChance;
    [SerializeField] private int assaultRifleChance;
    [SerializeField] private int shotGunChance;
    [SerializeField] private int sniperChance;
    #endregion

    #region FIELD
    
    #endregion

    #region UNITY
    private void Start()
    {
        score = 0f;
    }
    private void Update()
    {
        scoreText.text = "Score : " + (int)score;
    }
    #endregion


    #region METHODS
    public void EnemyDie()
    {
        score += 100;
        ItemDrop();
    }

    public void ItemDrop()
    {
        int rand = Random.Range(1,101);
        if(rand <= grenadeChance)
        {
            Debug.Log("Add : grenade");
            characterBehaviour.AddGrenade();
        }
        else if(rand <= assaultRifleChance+grenadeChance)
        {
            Debug.Log("Add : assaultRifle");
            assaultRifle.AddAmmo();
        }
        else if(rand <= shotGunChance+assaultRifleChance + grenadeChance)
        {
            Debug.Log("Add : shotGun");
            shotGun.AddAmmo();
        }
        else if(rand <= sniperChance+shotGunChance + assaultRifleChance + grenadeChance)
        {
            Debug.Log("Add : sniper");
            sniper.AddAmmo();
        }
    }
    #endregion
}
