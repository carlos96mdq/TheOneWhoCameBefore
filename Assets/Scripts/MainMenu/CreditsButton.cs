using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : Buttons
{
    public override void OnClick() {
        MainMenuManager.instance.OpenCreditsScreen();
    }
}
