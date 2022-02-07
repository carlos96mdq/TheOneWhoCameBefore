using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool isPlayerRunning = false; // Indica si el Player está corriendo
    public static bool isPlayerMoving = false;  // Indica si el Player está en movimiento
    
    public float movementSpeed = 5f;
    public float runningFactor = 2f;            // Indica en cuantas veces aumenta la velocidad al correr

    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        // Toma los valores de los inputs para moverse hacia adelante, atras y los costados
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Comprueba si está apretado el boton para correr
        if(Input.GetAxis("Run") != 0f && verticalMovement != 0f) {
            isPlayerRunning = true;
        }
        else {
            isPlayerRunning = false;
        }

        // A partir de los inputs obtiene el vector de movimiento
        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;
        if(move.magnitude != 0f) {
            isPlayerMoving = true;
        }
        else {
            isPlayerMoving = false;
        }

        // Realizo el movimiento
        if(isPlayerRunning) {
            controller.Move(move.normalized * runningFactor * movementSpeed * Time.deltaTime);
        }
        else if(isPlayerMoving) {
            controller.Move(move.normalized * movementSpeed * Time.deltaTime);
        }    
    }
}
