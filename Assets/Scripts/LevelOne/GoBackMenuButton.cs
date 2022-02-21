using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackMenuButton : MonoBehaviour
{
    public void OnClick() { 
        GameManager.instance.LoadScene(0);      // Cargo el MainMenu
    }
}
