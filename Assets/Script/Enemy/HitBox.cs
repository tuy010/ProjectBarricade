using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    #region FIELDS SERIALIZED
    enum Type
    {
        HEAD,
        BODY,
        OTHER,
    }
    [Title("Part")]
    [SerializeField] private Type type;

    #endregion

    #region FIELDS
    private float dmgRation;
    private Enemy enemy;
    #endregion

    #region UNITY
    //private void Start()
    //{
    //    switch (type)
    //    {
    //        case Type.HEAD:
    //            dmgRation = 1.5f;
    //            break;
    //        case Type.BODY:
    //            dmgRation = 1.0f;
    //            break;
    //        default:
    //            dmgRation = 0.8f;
    //            break;
    //    }
    //}
    #endregion

    #region METHODS
    public void Init(Enemy e, int t = -1)
    {
        enemy = e;
        switch(t)
        {
            case 0:
                type = Type.HEAD;
                dmgRation = 1.5f;
                break;
            case 1:
                type = Type.BODY;
                dmgRation = 1.0f;
                break;
            default:
                type = Type.OTHER;
                dmgRation = 0.8f;
                break;
        }
    }
    
    public void HitFunction(float dmg, bool isStunBullet)
    {
        enemy.GetDmg(dmg*dmgRation, isStunBullet);
    }
    #endregion
}
