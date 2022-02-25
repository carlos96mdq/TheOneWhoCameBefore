using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    float gravity;                          // Valor de gravedad, necesario para aplicarle a falta de rigidbody
    float movementSpeed;
    float runningFactor;                    // Indica en cuantas veces aumenta la velocidad al correr
    //bool isGrounded = false;                    // Indica verdadero si se está tocando el piso
    Vector3 fallVelocity = Vector3.zero;    // Undica la velocidad de caida
    CharacterController controller;
    PlayerStamina playerStamina;            // Script que contiene los datos de las stamina del player 

    public bool isRunning = false;          // Indica si el Player está corriendo
    public bool isMoving = false;           // Indica si el Player está en movimiento
    public CharacterConstants constants;    // Constantes                      

    void Start()
    {
        gravity = constants.gravity;
        movementSpeed = constants.movementSpeed;
        runningFactor = constants.runningFactor;
        
        controller = GetComponent<CharacterController>();
        playerStamina = GetComponent<PlayerStamina>();
    }

    // Update is called once per frame
    void Update()
    {
        // El player solo puede moverse si no se encuentra exausto 
        if(!playerStamina.GetExhasutedState()) {
            Movement();
        }
        else {
            playerStamina.RecoverStamina();
            isMoving = false;
            isRunning = false;
        }
        Gravity();
    }

    void Movement() {
        // Toma los valores de los inputs para moverse hacia adelante, atras y los costados
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Comprueba si está apretado el boton para correr
        if(Input.GetAxis("Run") != 0f && verticalMovement != 0f) {
            isRunning = true;
        }
        else {
            isRunning = false;
        }

        // A partir de los inputs obtiene el vector de movimiento
        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;
        if(move.magnitude != 0f) {
            isMoving = true;
        }
        else {
            isMoving = false;
        }

        // Realizo el movimiento
        if(isRunning) {
            controller.Move(move.normalized * runningFactor * movementSpeed * Time.deltaTime);
            playerStamina.ConsumeStamina();
        }
        else if(isMoving) {
            controller.Move(move.normalized * movementSpeed * Time.deltaTime);
            playerStamina.RecoverStamina();
        }
        else {
            playerStamina.RecoverStamina();
        }    
    }

    // Maneja la gravedad a falta de RigidBody
    // No está implementada correctamente, pero como no hay salto por ahora queda así
    void Gravity() {
        // fallVelocity.y += gravity * Time.deltaTime;
        fallVelocity.y = gravity;
        controller.Move(fallVelocity * Time.deltaTime);
    }
}
