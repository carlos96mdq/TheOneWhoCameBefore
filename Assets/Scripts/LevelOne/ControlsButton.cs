using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : Buttons
{
    public override void OnClick() {
        LevelOneManager.instance.ClosePause();      // Cierro el PauseMenu
        LevelOneManager.instance.OpenControls();    // Abro el SettingsMenus
    }
}
