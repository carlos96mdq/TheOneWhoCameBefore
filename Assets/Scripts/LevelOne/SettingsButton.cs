using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : Buttons
{
    public override void OnClick() {
        LevelOneManager.instance.ClosePause();      // Cierro el PauseMenu
        LevelOneManager.instance.OpenSettings();    // Abro el SettingsMenus
    }
}
