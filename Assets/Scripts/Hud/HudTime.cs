using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // Necesario para usar TextMeshProUGUI

/* HudTime Class
** Muestra en pantalla el tiempo transcurrido en segundos
*/
public class HudTime : MonoBehaviour
{
    //************************** Variables **************************//
    //Private
    TextMeshProUGUI timeCounterText;           

    //Public
    public GameObject timeCounter;  // Contador de tiempo de juego en HUD

    //************************** System Methods **************************//
    void Start() {
        timeCounterText = timeCounter.GetComponent<TextMeshProUGUI>();      // Asocio el texto en el Hud con el contador
        ShowTime();
    }

    void Update() {
        ShowTime();
    }

    //************************** Methods **************************//

    // Muestra en pantalla el tiempo transucrrido
    void ShowTime() {
        float gameActualTime = LevelOneManager.instance.levelTimer;
        timeCounterText.text = Math.Truncate(gameActualTime).ToString();
    }
}
