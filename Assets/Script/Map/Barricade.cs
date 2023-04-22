using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    #region FIELD SERIALIZED
    [Title("Status")]
    [SerializeField]
    private float hp;
    #endregion

    #region METHODS
    public void GetDmg(float dmg)
    {
        hp-=dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
    #endregion
}
