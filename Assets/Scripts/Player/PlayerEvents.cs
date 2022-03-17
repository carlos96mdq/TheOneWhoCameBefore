using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerEvents Class
** Se encarga de manejar los eventos del Player 
*/
public class PlayerEvents : MonoBehaviour
{
    //************************** Events **************************//
    public event Action<PlayerControl.State> onStateChange;   // Evento que salta al cambiar de estado

    //************************** Variables **************************//
    // Public    
    public PlayerAnimation playerAnimation; // Script PlayerAnimation
    public PlayerAudio playerAudio;         // Script PlayerAudio
    
    //************************** System Methods **************************//
    void Start() {
        // Agrego funciones al evento onStateChange
        onStateChange += playerAnimation.ChangeAnimationState;
        onStateChange += playerAudio.ChangePitch;
        onStateChange += playerAudio.Play;
    }
    
    //************************** Methods **************************//

    // Invocación del handler
    public void InvokeOnStateChange(PlayerControl.State state) {
        onStateChange?.Invoke(state);
    }
}
