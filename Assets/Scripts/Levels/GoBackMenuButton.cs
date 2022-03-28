using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackMenuButton : Buttons
{
    public override void OnClick() { 
        GameManager.instance.LoadScene(0);      // Cargo el MainMenu
    }
}
