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
    public bool isRunning = false;                  // Indica si el Minotauro está corriendo o no, es usada por otros scripts
    public CharacterConstants constants;            // Constantes

    //************************** System Methods **************************//
    void Start()
    {
        movementSpeed = constants.movementSpeed;
        runningFactor = constants.runningFactor;

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
/*     void Update()
    {
        // El actuar del Minotauro está determinado por una maquina de estados
        switch (mode) {
            case 0:
                SearchingMode();
                break;
            
            case 1:
                ChasingMode();
                break;
        }
    }
 */
    //************************** Methods **************************//

    // Avanza para adelante
    public void MoveForward() {
        // Si está corriendo, aumenta la velocidad
        if(isRunning) {
            controller.Move(transform.forward * movementSpeed * runningFactor * Time.deltaTime);
        }
        else {
            controller.Move(transform.forward * movementSpeed * Time.deltaTime);
        }
    }

}
