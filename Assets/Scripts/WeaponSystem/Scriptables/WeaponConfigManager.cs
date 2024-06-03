using FPS.PlayerSystem;
using FPS.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponConfigManager : MonoBehaviour
{
    public List<WeaponDataConfig> weaponList;

    void Start()
    {
        InitData();
    }

    private void InitData()
    {
        foreach (var weapon in weaponList)
        {
            var weaponData = new FP_Weapon(weapon.WeaponClass, weapon.Type, weapon.Damage, weapon.Ammo,
                weapon.MagSize, weapon.FireRate, weapon.OverheatDelay, weapon.ZoomFOV);
            PlayerStateManager.AddWeapon(weapon.Type, weaponData);
        }

        PlayerStateManager.EquipWeapon(weaponList.First().Type);
    }
}
