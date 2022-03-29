using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* PlayerRotation Class
** Tiene todas las funciones para la rotación de la cámara y del Player
*/
public class PlayerRotation : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    System.Random randomNumber;         // La variableque alamacenará los valores pseudo-aleatorios
    float x_rotation;                   // Rotacion inicial (la rotación respecto al eje x es hecha de esta manera)
                                        // para poder en un futuro limitarla
    float rotationSpeed;                // Velocidad de rotación
    float mouseSensibility;             // Sensibilidad del mouse

    // Public
    public Transform player;            // Transform del player al que la camara sigue
    public CharacterConstants constants;// Constantes                      
                    
    
    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        x_rotation = 0f;
        rotationSpeed = constants.rotationSpeed;
        mouseSensibility = GameManager.instance.GetMouseSensibility();
    }

    //************************** Methods **************************//

    // Establece una rotación random del Player, idela para comenzar la partida
    public void RandomRotation() {
        if(!(GameManager.instance.GetLevelNumber() == 3)) {
            randomNumber = new System.Random((int)DateTime.Now.Ticks);          // Inicializo una nueva instancia de Random con un seed dependiente de la fecha y hora actual
            player.transform.localRotation = Quaternion.Euler(0f, randomNumber.Next(360), 0f); // Devuelve un angulo random        
        }
    }
    
    // A partir de los inputs ingresados por el jugador, rota al Player
    public void Rotation() {
        // Tomo el valor demovimiento tanto en el eje x como en el eje y del mouse
        float vertical_mouse = Input.GetAxis("Mouse Y") * rotationSpeed * mouseSensibility * Time.deltaTime;
        float horizontal_mouse = Input.GetAxis("Mouse X") * rotationSpeed * mouseSensibility * Time.deltaTime;

        if(vertical_mouse != 0f || horizontal_mouse != 0f) {
            // Almaceno el valor de y en una variable aparte para poderlo clampear entre -70° y +70°
            // Tener en cuenta que tengo que pasarlo a una segunda variable para incrementar o disminuir ese valor, 
            // y no igualarlo
            x_rotation -= vertical_mouse;
            x_rotation = Mathf.Clamp(x_rotation, -60f, 60f);
            
            transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f); // Rotación en vetical
            player.Rotate(new Vector3(0f, horizontal_mouse, 0f));           // Rotación en horizontal
        }
    }

    // Cambia la sensibilidad del mouse
    public void ChangeSensibility(float newSen) {
        mouseSensibility = newSen;
    }
}
