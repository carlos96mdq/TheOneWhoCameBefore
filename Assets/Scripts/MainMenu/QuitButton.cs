using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : Buttons
{
    public override void OnClick() {
        GameManager.instance.QuitGame();
    }
}
