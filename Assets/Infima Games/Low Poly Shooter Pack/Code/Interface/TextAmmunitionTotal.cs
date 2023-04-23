//Copyright 2022, Infima Games. All Rights Reserved.

using System.Globalization;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Total Ammunition Text.
    /// </summary>
    public class TextAmmunitionTotal : ElementText
    {
        #region METHODS
        
        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            if(equippedWeaponBehaviour.IsinfiniteAmmo())
            {
                textMesh.text = "∞";
            }
            else
            {
                //Total Ammunition.
                //float ammunitionTotal = equippedWeaponBehaviour.GetAmmunitionTotal();
                float ammunitionTotal = equippedWeaponBehaviour.GetAmmoHave();

                //Update Text.
                textMesh.text = ammunitionTotal.ToString(CultureInfo.InvariantCulture);
            }
            
        }
        
        #endregion
    }
}