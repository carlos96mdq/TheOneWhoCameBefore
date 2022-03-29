using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // Necesario para usar TextMeshProUGUI

/* Objetives Class
** Maneja el texto de Objetivos en el Hud
*/
public class Objetives : MonoBehaviour
{
    //************************** Variables **************************//
    //Private
    string []objetivesList = {
        "Find and activate the interruptor",
        "Find the staircases and climb them",
        "Get to the door and get out of the maze"
    };
    Sprite []spritesList;
    TextMeshProUGUI objetiveText;
    TextMeshProUGUI warningText;
    Image objetiveImage;

    //Public
    public GameObject hudObjetives;         // Lista de objetivos del HUD
    public GameObject hudObjetivesWarning;  // Warning para avisar de un nuevo objetivo
    public GameObject objetiveSprite;       // Sprite representativo del objetivo actual
    public Sprite interruptor;              // Sprite del interruptor 
    public Sprite staircases;               // Sprite del staircases 
    public Sprite door;                     // Sprite del door 
    
    //************************** System Methods **************************//
    void Start() {
        objetiveText = hudObjetives.GetComponent<TextMeshProUGUI>();
        warningText = hudObjetivesWarning.GetComponent<TextMeshProUGUI>();
        objetiveImage = objetiveSprite.GetComponent<Image>();
        spritesList = new Sprite[] {
            interruptor,
            staircases,
            door
        };
        UpdateObjetive(LevelManager.instance.initialObjetive);
    }

    //************************** Methods **************************//

    // Cambia el valor de index del objetivo actual
    public void UpdateObjetive(int index) {
        objetiveText.text = objetivesList[index];
        UpdateImage(index);
        StartCoroutine(ShowWarning(3));
    }

    // Cambiar la imagen en el hud de objetivos
    void UpdateImage(int index) {
        objetiveImage.sprite = spritesList[index];
    }

    //************************** Coroutines **************************//

    // Corutina para contar el tiempo en pantalla del mensaje de nuevo objetivo
    IEnumerator ShowWarning(float seconds) {
        warningText.text = "New Objetive";
        yield return new WaitForSeconds(seconds);
        warningText.text = "";

    }
}
