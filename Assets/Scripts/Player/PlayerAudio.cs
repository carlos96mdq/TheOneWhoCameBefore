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
    AudioSource footsteps;                  // Efecto de sonido de pazos

    // Public
    public CharacterConstants constants;    // Constantes
        PlayerControl playerControl;

    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        walkingFrecuency = constants.walkingFrecuency;
        runningFrecuency = constants.runningFrecuency;

        // Asigno cada audio
        footsteps = GetComponent<AudioSource>();
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
