using FPS.WeaponSystem;

namespace FPS.PlayerSystem
{
    public static class PlayerStateManager
    {
        private static WeaponStateManager weaponManager = new WeaponStateManager();

        public static void EquipWeapon(WeaponType type)
        {
            weaponManager.EquipWeapon(type);
        }

        public static void SwitchWeapon(WeaponType newType)
        {
            weaponManager.SwitchWeapon(newType);
        }

        public static void SwitchWeapon()
        {
            weaponManager.SwitchWeapon();
        }

        public static  void Attack()
        {
            weaponManager.Attack();
        }

        public static void Reload()
        {
            weaponManager.Reload();
        }

        public static void AddWeapon(WeaponType type, Weapon weapon)
        {
            weaponManager.AddWeapon(type, weapon);
        }

        public  static void RemoveWeapon(WeaponType type)
        {
            weaponManager.RemoveWeapon(type);
        }
    }
}

