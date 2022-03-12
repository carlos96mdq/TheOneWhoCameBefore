using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerMovement Class
** Tiene todas las funciones para el movimiento del Player
*/
public class PlayerMovement : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    float gravity;                          // Valor de gravedad, necesario para aplicarle a falta de rigidbody
    float movementSpeed;
    float runningFactor;                    // Indica en cuantas veces aumenta la velocidad al correr
    Vector3 fallVelocity;                   // Indica la velocidad de caida
    CharacterController controller;

    // Public
    public CharacterConstants constants;    // Constantes                      

    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        gravity = constants.gravity;
        movementSpeed = constants.movementSpeed;
        runningFactor = constants.runningFactor;
        fallVelocity = new Vector3(0, gravity, 0);
        controller = GetComponent<CharacterController>();
    }

    //************************** Methods **************************//
    
    // A partir de los inputs ingresados por el jugador, mueve al Player
    // Return: 0 si no se meuve, 1 si está caminando, 2 si está corriendo
    public int Movement() {
        // Toma los valores de los inputs para moverse hacia adelante, atras y los costados
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        // A partir de los inputs obtiene el vector de movimiento
        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;

        // Comprueba si el Player está quieto
        if(move.magnitude == 0f) {
            return 0;
        }
        // El Player se está moviendo
        else {
            // Compruebo si el Player está corriendo 
            if(Input.GetAxis("Run") != 0f) {
                controller.Move(move.normalized * move.magnitude * runningFactor * movementSpeed * Time.deltaTime);
                return 2;
            }
            // El Player está caminando
            else {
                controller.Move(move.normalized * move.magnitude * movementSpeed * Time.deltaTime); // El agregado de move.magnitude es para que el cambio de movimiento no se vea tan brusco
                return 1;
            }         
        }
    }

    // Maneja la gravedad a falta de RigidBody
    // No está implementada correctamente, pero como no hay salto por ahora queda así
    public void Gravity() {       
        controller.Move(fallVelocity * Time.deltaTime);
    }
}
