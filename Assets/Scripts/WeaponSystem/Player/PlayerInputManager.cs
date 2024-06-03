using FPS.PlayerSystem;
using FPS.WeaponSystem;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputManager : MonoBehaviour
{

    private void Update()
    {
        DoAttack();
        DoWeaponSwitch();
    }

    private void DoAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
             PlayerStateManager.Attack();
        }
    }

    private void DoWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            PlayerStateManager.SwitchWeapon(WeaponType.Pistol);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            PlayerStateManager.SwitchWeapon(WeaponType.Rifle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerStateManager.SwitchWeapon(WeaponType.Shotgun);
        }

    }
}
