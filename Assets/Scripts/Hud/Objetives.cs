using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // Necesario para usar TextMeshProUGUI

public class Objetives : MonoBehaviour
{
    string []objetivesList = {
        "Find and activate de interruptor",
        "Find the staircases and escape"
    };

    int actualObjetive = 0;

    public GameObject hudObjetives;   // Lista de objetivos del HUD
    TextMeshProUGUI objeiveText; 
    
    // Start is called before the first frame update
    void Start()
    {
        objeiveText = hudObjetives.GetComponent<TextMeshProUGUI>();
        objeiveText.text = objetivesList[actualObjetive];
    }

    public void NextObjetive() {
        actualObjetive++;
        objeiveText.text = objetivesList[actualObjetive];
    }
}
