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
    AudioSource footsteps;                  // Efecto de sonido de pazos

    // Public
    public CharacterConstants constants;    // Constantes

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
    public void Play(MinotaurControl.State state) {
        if(state == MinotaurControl.State.WALKING || state == MinotaurControl.State.RUNNING) {
            if(!footsteps.isPlaying) {
                Debug.Log("Se reproduce");
                footsteps.Play();
            }
        }
        else {
            Debug.Log("Deja de reproducirse");
            footsteps.Pause();
        }
    }
    
    // Cambia la velocidad del sonido de pasos acorde al estado del Minotaur
    public void ChangePitch(MinotaurControl.State state) {
        switch (state) {
            case MinotaurControl.State.WALKING:
            Debug.Log("Pitch cambiado");
                footsteps.pitch = walkingFrecuency;
                break;
            case MinotaurControl.State.RUNNING:
                footsteps.pitch = runningFrecuency;
                break;
            default:
                break;
        }  
    }

}
