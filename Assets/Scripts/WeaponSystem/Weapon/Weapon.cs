using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.WeaponSystem
{
    public enum WeaponClass
    {
        Primary,
        Secondary,
        Melee,
    }

    public enum WeaponType
    {
        Pistol,
        Rifle,
        Shotgun,
        Sniper,
        Grenade,
        RocketLauncher
    }

    /// <summary>
    /// Base class that other classes will derive from. Contains data and functionality which is fundamental to all weapon types.
    /// </summary>

    public class Weapon
    {
        public WeaponClass WeaponClass { get; private set; }
        public WeaponType Type { get; private set; }
        public int Damage { get; private set; }
        public int Ammo { get; private set; }
        public int MagSize { get; private set; }
        public float FireRate { get; private set; }
        public float OverheatDelay { get; private set; }
        public bool IsEquipped { get => isEquipped; set => isEquipped = value; }
        public bool IsReloading { get => isReloading; set => isReloading = value; }
        public float ZoomFOV { get; private set; } // Field of View (FOV) when zoomed

        private float defaultFOV; // Default field of view

        public bool HasAmmo => Ammo > 0;
        private bool isEquipped;
        private bool isReloading;
        private bool isZoomed;

        public Weapon(WeaponClass weaponClass, WeaponType type, int damage, int ammo, int magazineSize, float fireRate, float overheatDelay, float zoomFOV)
        {
            WeaponClass = weaponClass;
            Type = type;
            Damage = damage;
            Ammo = ammo;
            MagSize = magazineSize;
            FireRate = fireRate;
            OverheatDelay = overheatDelay;
            ZoomFOV = zoomFOV;
            defaultFOV = Camera.main.fieldOfView;
        }

        public Weapon()
        {
        }



        public bool CanReload()
        {
            if (isEquipped && HasAmmo)
            {
                isReloading = true;
                return true;
            }
            return false;
        }

        public void OnReload()
        {
            if (CanReload())
            {
                WeaponStateMachine.SetState(WeaponState.Reloading);
                Ammo = MagSize;
                isReloading = false;
            }
        }

        public void ToggleZoom()
        {
            isZoomed = !isZoomed;
            Camera.main.fieldOfView = isZoomed ? ZoomFOV : defaultFOV;
        }

        public void Attack()
        {
            if (CanFire())
            {
                Ammo--;
                //Debug.Log(Type.ToString() +" fired. Ammo remaining: " + Ammo);
                UIEvents.SetWeaponAmmo?.Invoke(Ammo);
            }
        }

        private bool CanFire()
        {
            if (!IsEquipped && isReloading)
            {
                return false;
            }

            if (Ammo == 0)
            {
                return false;
            }
            return true;
        }


    }
}


