//Copyright 2022, Infima Games. All Rights Reserved.

using InfimaGames.LowPolyShooterPack.Interface;
using TMPro;
using UnityEngine;

/// <summary>
/// Interface component that hides or shows the tutorial text based on input.
/// </summary>
public class ShowAmmoUI : ElementText
{
    #region FIELDS SERIALIZED

    [Title(label: "References")]

    [Tooltip("ShowAmmo")]
    [SerializeField]
    private GameObject gunAmmo;

    #endregion

    #region UNITY

    protected override void Awake()
    {
        //Base.
        base.Awake();
        gunAmmo.SetActive(false);
    }

    #endregion

    #region METHODS

    protected override void Tick()
    {
        bool isVisible = characterBehaviour.IsTutorialTextVisible();
        gunAmmo.SetActive(isVisible);
    }

    #endregion
}