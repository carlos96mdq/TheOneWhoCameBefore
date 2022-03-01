using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    float walkingFrecuency;                 // Velocidad de pazos en caminata
    float runningFrecuency;                 // Velocidad de pazos en corrida
    AudioSource footsteps;                  // Efecto de sonido de pazos
    PlayerMovement playerScript;            // Script de movimiento del Player, obtengo una referencia al mismo 
                                            // para utilizar sus variables publicas

    public CharacterConstants constants;    // Constantes
    
    void Start()
    {
        walkingFrecuency = constants.walkingFrecuency;
        runningFrecuency = constants.runningFrecuency;

        // Asigno cada audio
        footsteps = GetComponent<AudioSource>();
        footsteps.pitch = walkingFrecuency;

        playerScript = this.gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Si está en movimiento y no se está reproduciendo el efecto de sonido de pazos, se reproduce
        // Tener en cuenta que tanto cuando el Player está caminando, como cuando está corriendo
        // isPlayerMoving se encuentra en true, sólo está en false cuando el Player está quieto
        if(playerScript.isMoving && !footsteps.isPlaying) {
            footsteps.Play();
        }
    }

    // Se modifica la frecuencia del efecto de sonido de pazos dependiendo la velocidad de movimiento
    public void ChangePitch(int mode) {
        switch (mode)
        {
            case 1:
                footsteps.pitch = walkingFrecuency;
                break;
            case 2:
                footsteps.pitch = runningFrecuency;
                break;
        }
    }
}
