using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : Buttons
{
    public override void OnClick() {
        LevelOneManager.instance.ResumeGame();
    }
}
