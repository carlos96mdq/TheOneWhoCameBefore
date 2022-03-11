using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    float walkingFrecuency;                 // Velocidad de pazos en caminata
    float runningFrecuency;                 // Velocidad de pazos en corrida
    AudioSource footsteps;                  // Efecto de sonido de pazos

    public PlayerState playerState;         // Script que maneja el estado del Player
    public CharacterConstants constants;    // Constantes
    
    void Start()
    {
        walkingFrecuency = constants.walkingFrecuency;
        runningFrecuency = constants.runningFrecuency;

        // Asigno cada audio
        footsteps = GetComponent<AudioSource>();
        footsteps.pitch = walkingFrecuency;
    }

    void Update()
    {
        // Si está en movimiento y no se está reproduciendo el efecto de sonido de pazos, se reproduce
        if((playerState.IsWalking() || playerState.IsRunning()) && !footsteps.isPlaying) {
            footsteps.Play();
        }
    }

    // Cambia la velocidad del sonido de pasos acorde al estado del Player
    public void ChangePitch(PlayerState.State state) {
        switch (state)
        {
            case PlayerState.State.WALKING:
                footsteps.pitch = walkingFrecuency;
                break;
            case PlayerState.State.RUNNING:
                footsteps.pitch = runningFrecuency;
                break;
            default:
                break;
        }  
    }
}
