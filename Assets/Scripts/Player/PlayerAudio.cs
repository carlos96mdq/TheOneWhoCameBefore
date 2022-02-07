using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    AudioSource footsteps;          // Efecto de sonido de pazos
    float walkingFrecuency = 0.7f;  // Velocidad de pazos en caminata
    float runningFrecuency = 1f;    // Velocidad de pazos en corrida

    void Start()
    {
        // Asigno cada audio
        footsteps = GetComponent<AudioSource>();
        footsteps.pitch = walkingFrecuency;
    }

    void Update()
    {
        // Se modifica la frecuencia del efecto de sonido de pazos dependiendo la velocidad de movimiento
        if(PlayerMovement.isPlayerRunning) {
            footsteps.pitch = runningFrecuency;
        }
        // Si el Player está caminando pero no se está reproduciendo el efecto de sonido de caminar
        else if(PlayerMovement.isPlayerMoving) {
            footsteps.pitch = walkingFrecuency;
        }

        // Si está en movimiento y no se está reproduciendo el efecto de sonido de pazos, se reproduce
        // Tener en cuenta que tanto cuando el Player está caminando, como cuando está corriendo
        // isPlayerMoving se encuentra en true, sólo está enfalse cuando el Player está quieto
        if(PlayerMovement.isPlayerMoving && !footsteps.isPlaying) {
            footsteps.Play();
        }
    }
}
