using FPS.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FPS.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text equippedWeaponText;
        [SerializeField] private TMP_Text ammoText;
        [SerializeField] private TMP_Text stateText;

        private void OnEnable()
        {
            UIEvents.SetWeaponName += SetNameText;
            UIEvents.SetWeaponAmmo += SetAmmoText;
            UIEvents.ShowWeaponState += SetWeaponStateText;
        }

        private void OnDisable()
        {
            UIEvents.SetWeaponName -= SetNameText;
            UIEvents.SetWeaponAmmo -= SetAmmoText;
            UIEvents.ShowWeaponState -= SetWeaponStateText;
        }

        private void SetNameText(string name)
        {
            if(equippedWeaponText != null)
            {
                equippedWeaponText.text = name;
            }
        }
        private void SetAmmoText(int value)
        {
            if (ammoText != null)
            {
                ammoText.text = value.ToString();
            }
        }
        private void SetWeaponStateText(string name)
        {
            if (stateText != null)
            {
                stateText.text = name;
            }
        }

    }
}

