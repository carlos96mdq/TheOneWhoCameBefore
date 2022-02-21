using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public void OnClick() {
        MainMenuManager.instance.OpenSettingMenu();
    }
}
