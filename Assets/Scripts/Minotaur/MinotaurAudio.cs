using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAudio : MonoBehaviour
{
    float walkingFrecuency;                 // Velocidad de pazos en caminata
    float runningFrecuency;                 // Velocidad de pazos en corrida
    AudioSource footsteps;                  // Efecto de sonido de pazos
    MinotaurMovement minotaurScript;        // Script de movimiento del Minotauro, obtengo una referencia al mismo 
                                            // para utilizar sus variables publicas

    public CharacterConstants constants;    // Constantes

    void Start()
    {
        walkingFrecuency = constants.walkingFrecuency;
        runningFrecuency = constants.runningFrecuency;

        // Asigno cada audio
        footsteps = GetComponent<AudioSource>();
        footsteps.pitch = walkingFrecuency;

        minotaurScript = this.gameObject.GetComponent<MinotaurMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Se modifica la frecuencia del efecto de sonido de pazos dependiendo la velocidad de movimiento
        if(minotaurScript.isRunning) {
            footsteps.pitch = runningFrecuency;
        }
        // Si el Player está caminando pero no se está reproduciendo el efecto de sonido de caminar
        else {
            footsteps.pitch = walkingFrecuency;
        }

        // Si está en movimiento y no se está reproduciendo el efecto de sonido de pazos, se reproduce
        // Tener en cuenta que tanto cuando el Player está caminando, como cuando está corriendo
        // isPlayerMoving se encuentra en true, sólo está enfalse cuando el Player está quieto
        if(!footsteps.isPlaying) {
            footsteps.Play();
        }
    }
}
