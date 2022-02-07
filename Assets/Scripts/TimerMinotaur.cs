using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMinotaur : MonoBehaviour
{
    float timerOne = 0f;        // Timer uno: encargado de la aparición del Minotauro
    float timerOneLimit = 10f;  // Limite del Timer uno: 30 segundos
    bool timerOneActive;        // Indica si el Timer uno está activado
    float timerTwo = 0f;        // Timer dos: encargado de la aparición de un segundo Minotauro
    float timerTwoLimit = 20f; // Limite del Timer dos: 5 minutos
    bool timerTwoActive;        // Indica si elTimer dos está activado
    GameObject minotaur;        // El gameobject del Minotauro
    GameObject minotaurTwo;     // El gameobject del segundo Minotauro
    
    void Start()
    {
        // Al iniciar desactivo a los minotauros
        minotaur = GameObject.Find("Enemy");
        minotaur.SetActive(false);  
        minotaurTwo = GameObject.Find("Enemy_2");
        minotaurTwo.SetActive(false); 

        // Activo timers
        timerOneActive = true; 
        timerTwoActive = true;          
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOneActive) {
            TimerOneCounter();
        }
        if(timerTwoActive) {
            TimerTwoCounter();
        }
    }

    void TimerOneCounter() {
        // Aumento el timer
        timerOne += Time.deltaTime;

        // Verifico la condición
        if(timerOne > timerOneLimit) {
            // Activo al Minotauro
            minotaur.SetActive(true);
            timerOneActive = false;
        }
    }

    void TimerTwoCounter() {
        // Aumento el timer
        timerTwo += Time.deltaTime;

        // Verifico la condición
        if(timerTwo > timerTwoLimit) {
            // Aumento la velocidad del Minotauro
            minotaurTwo.SetActive(true);
            timerTwoActive = false;
        }
    }
}
