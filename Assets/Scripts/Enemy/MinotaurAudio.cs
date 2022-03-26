using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* MinotaurAudio Class
** Tiene todas las funciones para la reproducción de los audios provenientes del Minotauro
*/
public class MinotaurAudio : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    float walkingFrecuency;                 // Velocidad de pazos en caminata
    float runningFrecuency;                 // Velocidad de pazos en corrida

    // Public
    public AudioSource footsteps;           // Efecto de sonido de pazos
    public AudioSource roar;                // Efecto de sonido de rugido
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
    public void Play(MinotaurControl.State state) {
        if(state == MinotaurControl.State.WALKING || state == MinotaurControl.State.RUNNING || state == MinotaurControl.State.BACKING) {
            if(!footsteps.isPlaying) {
                footsteps.Play();
            }
        }
        else {
            footsteps.Pause();
        }

        if(state == MinotaurControl.State.ROARING) {
            roar.Play();
        }
    }
    
    // Cambia la velocidad del sonido de pasos acorde al estado del Minotaur
    public void ChangePitch(MinotaurControl.State state) {
        switch (state) {
            case MinotaurControl.State.WALKING: case MinotaurControl.State.BACKING:
                footsteps.pitch = walkingFrecuency;
                break;
            case MinotaurControl.State.RUNNING:
                footsteps.pitch = runningFrecuency;
                break;
        }  
    }

}
