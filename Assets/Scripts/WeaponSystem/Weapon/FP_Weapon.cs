using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.WeaponSystem
{
    /// <summary>
    /// First Person Weapon class that derives Weapon class, will handle all Unity-specific components like animations, audio etc
    /// </summary>
    public class FP_Weapon : Weapon
    {
        [SerializeField] private Camera weaponCamera;
        [SerializeField] private GameObject weaponPrefab;
        public float ShakeSpeed = 0.05f;
        public float BobSpeed = 0.05f; 
        public float ZoomSpeed = 0.05f;
        [SerializeField] private AudioClip wieldClip;
        [SerializeField] private AudioSource audioSource;

        public FP_Weapon(WeaponClass weaponClass, WeaponType type, int damage, int ammo, int magazineSize, float fireRate, float overheatDelay, float zoomFOV) : base( weaponClass, type, damage, ammo, magazineSize, fireRate, overheatDelay, zoomFOV)
        {
        }

        private void UpdateZoom()
        {
            // add functionality to zoom a weapon on button hold
        }

        private void UpdateBob()
        {
            // add functionality to bob a weapon on player running state
        }

        private void UpdateShake()
        {
            // add functionality to shake a weapon when player is shot or an explosion occurs beside player
        }



    }
}




