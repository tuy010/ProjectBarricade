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

    [Title("GetItemUI")]
    [SerializeField] private GameObject GetItemPrefab;

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
            ItemDropShowUI(0);
        }
        else if(rand <= assaultRifleChance+grenadeChance)
        {
            Debug.Log("Add : assaultRifle");
            assaultRifle.AddAmmo();
            ItemDropShowUI(1);
        }
        else if(rand <= shotGunChance+assaultRifleChance + grenadeChance)
        {
            Debug.Log("Add : shotGun");
            shotGun.AddAmmo();
            ItemDropShowUI(2);
        }
        else if(rand <= sniperChance+shotGunChance + assaultRifleChance + grenadeChance)
        {
            Debug.Log("Add : sniper");
            sniper.AddAmmo();
            ItemDropShowUI(3);
        }
    }

    private void ItemDropShowUI(int type)
    {
        TextMeshProUGUI text = Instantiate(GetItemPrefab).GetComponent<GetItemUI>().GetText();
        switch(type)
        {
            case 0:
                text.text = "Grenade +1";
                break;
            case 1:
                text.text = "AR +32";
                break;
            case 2:
                text.text = "Shotgun +8";
                break;
            case 3:
                text.text = "Sniper +8";
                break;
            default:
                text.text = "";
                break;
        }
    }
    #endregion
}
