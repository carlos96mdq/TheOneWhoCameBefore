using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudTime : MonoBehaviour
{
    public GameObject timeCounter;   // Contador de tiempo de juego en HUD

    Text timeCounterText;           
    
    void Start()
    {
        timeCounterText = timeCounter.GetComponent<Text>(); // Asocio el texto en el Hud con el contador
        timeCounterText.text = GameManager.instance.gameTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounterText.text = GameManager.instance.gameTimer.ToString();
    }
}
