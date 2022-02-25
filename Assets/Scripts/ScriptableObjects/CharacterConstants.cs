using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterConstants", order = 1)]
public class CharacterConstants :  ScriptableObject
{
    // General
    public float gravity;           // Gravedad
    
    // Movement
    public float movementSpeed;     // Velocidad de movimiento
    public float runningFactor;     // Indica en cuantas veces aumenta la velocidad al correr

    // Animation
    public float walkingFrecuency;  // Velocidad de pazos en caminata
    public float runningFrecuency;  // Velocidad de pazos en corrida
}
