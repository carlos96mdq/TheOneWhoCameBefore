using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMinotaur : MonoBehaviour
{
    float timerOne = 0f;        // Timer uno: encargado de la aparición del Minotauro
    float timerOneLimit = 15f;  // Limite del Timer uno: 15 segundos
    bool timerOneActive;        // Indica si el Timer uno está activado
    float timerTwo = 0f;        // Timer dos: encargado de la aparición de un segundo Minotauro
    float timerTwoLimit = 60f;  // Limite del Timer dos: 1 minuto
    bool timerTwoActive;        // Indica si el Timer dos está activado
    GameObject minotaur;        // El gameobject del Minotauro
    
    void Start()
    {
        // Al iniciar desactivo a los minotauros
        minotaur = GameObject.Find("Enemy");
        minotaur.SetActive(false);  

        // Activo timers
        timerOneActive = true; 
        timerTwoActive = false;          
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
            timerTwoActive = true;
        }
    }

    void TimerTwoCounter() {
        // Aumento el timer
        timerTwo += Time.deltaTime;

        // Verifico la condición
        if(timerTwo > timerTwoLimit) {
            // Aparece un nuevo Minotauro
            Instantiate(minotaur, new Vector3(0f,6.30000019f,0f), new Quaternion(0,0,0,1));
            timerTwo = 0f;
        }
    }
}
