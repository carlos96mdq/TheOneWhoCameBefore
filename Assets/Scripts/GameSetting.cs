using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    void Awake() 
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // Para forzar el cierre del juego
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }
}
