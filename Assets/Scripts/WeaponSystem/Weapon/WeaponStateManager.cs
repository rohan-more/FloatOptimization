using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.WeaponSystem
{
    public enum WeaponState
    {
        Idle,
        Equipped,
        Switching,
        Firing,
        Reloading,
        Zoomed
    }
    public static class WeaponStateMachine
    {
        private static WeaponState currentState = WeaponState.Idle;

        public static void SetState(WeaponState newState)
        {
            currentState = newState;
            UIEvents.ShowWeaponState?.Invoke(GetStateName());
        }

        public static WeaponState GetState()
        {
            return currentState;
        }

        public static string GetStateName()
        {
            return currentState.ToString();
        }
    }

    public class WeaponStateManager
    {
        private Weapon currentWeapon;
        private Dictionary<WeaponType, Weapon> weapons = new Dictionary<WeaponType, Weapon>();
        private bool isReloading;

        /// <summary>
        /// Equip given weapon
        /// </summary>
        /// <param name="type"></param>
        public void EquipWeapon(WeaponType type)
        {
            if (weapons.ContainsKey(type))
            {
                WeaponStateMachine.SetState(WeaponState.Equipped);
                currentWeapon = weapons[type];
                currentWeapon.IsEquipped = true;
                UIEvents.SetWeaponName?.Invoke(currentWeapon.Type.ToString());
                UIEvents.SetWeaponAmmo?.Invoke(currentWeapon.Ammo);
            }
        }

        /// <summary>
        /// Switch to given weapon
        /// </summary>
        /// <param name="newType"></param>
        public void SwitchWeapon(WeaponType newType)
        {
            if (weapons.ContainsKey(newType))
            {
                currentWeapon.IsEquipped = false;
                WeaponStateMachine.SetState(WeaponState.Switching);
                UIEvents.SetWeaponName?.Invoke(newType.ToString());
                EquipWeapon(newType);
            }
        }

        public void SwitchWeapon()
        {
            foreach (var weapon in weapons.Values)
            {
                if(currentWeapon != weapon)
                {
                    SwitchWeapon(weapon.Type);
                }
            }
        }

        /// <summary>
        /// Attack using equipped weapon
        /// </summary>
        public void Attack()
        {
            if (!isReloading && currentWeapon != null)
            {
                WeaponStateMachine.SetState(WeaponState.Firing);
                if (currentWeapon.Ammo <= 0)
                {
                    Reload();
                }
                currentWeapon.Attack();
            }
        }

        public void Reload()
        {
            if (!isReloading && currentWeapon != null)
            {
                isReloading = true;
                currentWeapon.OnReload();
                isReloading = false;
            }
        }

        public void AddWeapon(WeaponType type, Weapon weapon)
        {
            weapons[type] = weapon;
        }

        public void RemoveWeapon(WeaponType type)
        {
            weapons.Remove(type);
        }
    }
}


