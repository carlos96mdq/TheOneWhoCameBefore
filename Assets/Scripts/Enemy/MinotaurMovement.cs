using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* MinotaurMovement Class
** Maneja el movimiento del Minotauro
*/
public class MinotaurMovement : MonoBehaviour
{   
    //************************** Variables **************************//
    // Private
    float movementSpeed;                            // Velocidad de movimiento
    float runningFactor;                            // Indica en cuantas veces aumenta la velocidad al correr
    CharacterController controller;

    // Public    
    public CharacterConstants constants;            // Constantes

    //************************** System Methods **************************//
    void Start() {
        movementSpeed = constants.movementSpeed;
        runningFactor = constants.runningFactor;

        controller = GetComponent<CharacterController>();
    }

    //************************** Methods **************************//

    // Avanza para adelante
    public void MoveForward(bool isRunning) {
        // Si está corriendo, aumenta la velocidad
        if(isRunning) {
            controller.Move(transform.forward * movementSpeed * runningFactor * Time.deltaTime);
        }
        else {
            controller.Move(transform.forward * movementSpeed * Time.deltaTime);
        }
    }

}
