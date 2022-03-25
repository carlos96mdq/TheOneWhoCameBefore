using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // Necesario para usar TextMeshProUGUI

public class HudTime : MonoBehaviour
{
    public GameObject timeCounter;   // Contador de tiempo de juego en HUD

    TextMeshProUGUI timeCounterText;           
    
    void Start()
    {
        timeCounterText = timeCounter.GetComponent<TextMeshProUGUI>(); // Asocio el texto en el Hud con el contador
        ShowTime();
    }

    // Update is called once per frame
    void Update()
    {
        ShowTime();
    }

    void ShowTime() {
        float gameActualTime = LevelOneManager.instance.levelTimer;
        timeCounterText.text = Math.Truncate(gameActualTime).ToString();
        // timeCounterText.text = Math.Truncate(gameActualTime).ToString() + ":";
        // timeCounterText.text += Math.Truncate((gameActualTime - Math.Truncate(gameActualTime)) * 100).ToString();
    }
}
