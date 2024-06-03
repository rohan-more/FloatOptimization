using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS.WeaponSystem;

[CreateAssetMenu]
public class WeaponDataConfig : ScriptableObject
{
    public WeaponClass WeaponClass;
    public WeaponType Type;
    public int Damage;
    public int Ammo;
    public int MagSize;
    public float FireRate;
    public float OverheatDelay;
    public float ZoomFOV; // Field of View (FOV) when zoomed
}
