using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterConstants", order = 1)]
public class CharacterConstants :  ScriptableObject
{
    // General
    public float gravity;               // Gravedad
    
    // Movement
    public float movementSpeed;         // Velocidad de movimiento
    public float runningFactor;         // Indica en cuantas veces aumenta la velocidad al correr

    // Rotation
    public float rotationSpeed;         // Velocidad de rotación

    // Animation
    public float walkingFrecuency;      // Velocidad de pazos en caminata
    public float runningFrecuency;      // Velocidad de pazos en corrida

    // Stamina
    public float consumeStaminaFactor;  // Indica el factor en el cual baja la stamina
    public float recoverStaminaFactor;  // Indica el factor en el cual sube la stamina      
    public float maxStamina;            // Indica la stamina máxima
    public float recoverTime;           // El tiempo en segundos que tarda en recuperarse para poder

}
