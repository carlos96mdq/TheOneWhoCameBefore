using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    float gravity;                          // Valor de gravedad, necesario para aplicarle a falta de rigidbody
    float movementSpeed;
    float runningFactor;                    // Indica en cuantas veces aumenta la velocidad al correr
    //bool isGrounded = false;                    // Indica verdadero si se está tocando el piso
    Vector3 fallVelocity = Vector3.zero;    // Indica la velocidad de caida
    CharacterController controller;
    PlayerStamina playerStamina;            // Script que contiene los datos de las stamina del player 

    public bool isRunning = false;          // Indica si el Player está corriendo
    public bool isMoving = false;           // Indica si el Player está en movimiento
    public PlayerEvents playerEvents;       // Script con los eventos del Player
    public PlayerState playerState;         // Script que maneja el estado del Player
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
        if(playerState.IsRecovering()) {
            playerStamina.RecoverStamina();  
        }
        else {
            Movement();
        }
        Gravity();
    }

    void Movement() {
        // Toma los valores de los inputs para moverse hacia adelante, atras y los costados
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        // A partir de los inputs obtiene el vector de movimiento
        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;

        // Comprueba si el Player está quieto
        if(move.magnitude == 0f) {
            if(!playerState.IsIdle()) {
                playerState.StateIdle();
                playerEvents.InvokeOnStateChange(playerState.GetState());
            }
            // Recupero stamina
            playerStamina.RecoverStamina();
            return;
        }
        // El Player se está moviendo
        else {
            // Compruebo si el Player está corriendo 
            if(Input.GetAxis("Run") != 0f) {
                if(!playerState.IsRunning()) {
                    playerState.StateRuning();
                    playerEvents.InvokeOnStateChange(playerState.GetState());
                }
                controller.Move(move.normalized * move.magnitude * runningFactor * movementSpeed * Time.deltaTime);
                playerStamina.ConsumeStamina();
            }
            // El Player está caminando
            else {
                if(!playerState.IsWalking()) {
                    playerState.StateWalking();
                    playerEvents.InvokeOnStateChange(playerState.GetState());
                }
                // El agregado de move.magnitude es para que el cambio de movimiento no se vea tan brusco
                controller.Move(move.normalized * move.magnitude * movementSpeed * Time.deltaTime);
                playerStamina.RecoverStamina();
            }         
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
