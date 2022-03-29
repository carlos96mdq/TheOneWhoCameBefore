using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // Necesario para usar TextMeshProUGUI

public class Objetives : MonoBehaviour
{
    string []objetivesList = {
        "Get to the door and get out of the maze"
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
