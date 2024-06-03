using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIEvents
{
    public static Action<string> ShowWeaponState;
    public static Action<string> SetWeaponName;
    public static Action<int> SetWeaponAmmo;
}
