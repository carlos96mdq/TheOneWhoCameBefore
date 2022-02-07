using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    float walkingFrecuency = 0.7f;  // Velocidad de pazos en caminata
    float runningFrecuency = 1f;    // Velocidad de pazos en corrida
    AudioSource footsteps;          // Efecto de sonido de pazos
    PlayerMovement playerScript;    // Script de movimiento del Player, obtengo una referencia al mismo 
                                    // para utilizar sus variables publicas
    
    void Start()
    {
        // Asigno cada audio
        footsteps = GetComponent<AudioSource>();
        footsteps.pitch = walkingFrecuency;

        playerScript = this.gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Se modifica la frecuencia del efecto de sonido de pazos dependiendo la velocidad de movimiento
        if(playerScript.isRunning) {
            footsteps.pitch = runningFrecuency;
        }
        // Si el Player está caminando pero no se está reproduciendo el efecto de sonido de caminar
        else if(playerScript.isMoving) {
            footsteps.pitch = walkingFrecuency;
        }

        // Si está en movimiento y no se está reproduciendo el efecto de sonido de pazos, se reproduce
        // Tener en cuenta que tanto cuando el Player está caminando, como cuando está corriendo
        // isPlayerMoving se encuentra en true, sólo está enfalse cuando el Player está quieto
        if(playerScript.isMoving && !footsteps.isPlaying) {
            footsteps.Play();
        }
    }
}
