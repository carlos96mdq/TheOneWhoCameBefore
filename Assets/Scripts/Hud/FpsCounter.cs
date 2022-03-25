using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // Necesario para usar TextMeshProUGUI


/* FpsCounter Class
** Muestra en pantalla los fps
*/
public class FpsCounter : MonoBehaviour
{
    //************************** Constants **************************//
    const float maxCounter = 0.7f;   // Overflow del contador

    //************************** Variables **************************//
    //Private
    float counter;  // Contador de tiempo
    TextMeshProUGUI fpsCounterText;   

    //Public
    public GameObject fpsCounter;   // Contador de fps, temporal

    //************************** System Methods **************************//
    void Start() {
        counter = 0f;
        fpsCounterText = fpsCounter.GetComponent<TextMeshProUGUI>();    // Asocio el texto en el Hud con el de los fps
    }

    void Update() {
        // Aplico un sistema de conteo para mostras los fps solo cada maxCounter segundos
        counter += Time.deltaTime;
        if(counter >= maxCounter) {
            counter = 0f;
            ShowFps(1 / Time.unscaledDeltaTime);
        }
    }

    //************************** Methods **************************//

    // Muestra en pantalla los fps
    void ShowFps(float fps) {
        fpsCounterText.text = "fps " + Math.Truncate(fps).ToString();
    }
}
