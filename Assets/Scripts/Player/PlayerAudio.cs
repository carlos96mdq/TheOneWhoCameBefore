using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerAudio Class
** Tiene todas las funciones para la reproducción de los audios provenientes del Player
*/
public class PlayerAudio : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    float walkingFrecuency;                 // Velocidad de pazos en caminata
    float runningFrecuency;                 // Velocidad de pazos en corrida

    // Public
    public AudioSource footsteps;           // Efecto de sonido de pazos
    public AudioSource breath;              // Efecto de sonido de la respiración
    public AudioSource heavyBreath;              // Efecto de sonido de la respiración pesada al estar cansado
    public CharacterConstants constants;    // Constantes

    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        walkingFrecuency = constants.walkingFrecuency;
        runningFrecuency = constants.runningFrecuency;

        // Asigno cada audio
        footsteps.pitch = walkingFrecuency;
    }

    //************************** Methods **************************//

    // Reproduce el sonido de pasos o lo detiene dependiendo el caso
    public void Play(PlayerControl.State state) {
        if(state == PlayerControl.State.WALKING || state == PlayerControl.State.RUNNING) {
            if(!footsteps.isPlaying) {
                footsteps.Play();
            }
        }
        else {
            footsteps.Pause();
        }

        if(state == PlayerControl.State.RUNNING) {
            if(!breath.isPlaying) {
                breath.Play();
            }
        }
        else {
            breath.Stop();
        }

        if(state == PlayerControl.State.RECOVERING) {
            if(!breath.isPlaying) {
                heavyBreath.Play();
            }
        }
        else {
            heavyBreath.Stop();
        }
    }
    
    // Cambia la velocidad del sonido de pasos acorde al estado del Player
    public void ChangePitch(PlayerControl.State state) {
        switch (state) {
            case PlayerControl.State.WALKING:
                footsteps.pitch = walkingFrecuency;
                break;
            case PlayerControl.State.RUNNING:
                footsteps.pitch = runningFrecuency;
                break;
            default:
                break;
        }  
    }
}
