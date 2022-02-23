using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;     // Velocidad de movimiento
    public float runningFactor;     // Indica en cuantas veces aumenta la velocidad al correr
    public bool isRunning;          // Indica si el Player está corriendo
    public bool isMoving;           // Indica si el Player está en movimiento

    CharacterController controller; // Character Controller del personaje de movimiento

    // Start is called before the first frame update
    public virtual void Start()
    {
        controller = GetComponent<CharacterController>();
    }
}
