using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnClick() {
        MainMenuManager.instance.ActiveLoadingScreen(); // Activa la pantalla de carga
        GameManager.instance.LoadScene(1);              // Comienza a cargar el nuevo nivel
    }
}
