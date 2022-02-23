using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : Buttons
{
    public override void OnClick() {
        MainMenuManager.instance.OpenSettingMenu();
    }
}
