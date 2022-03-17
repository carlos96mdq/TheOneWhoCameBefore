using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* MinotaurEvents Class
** Se encarga de manejar los eventos del Minotaur 
*/
public class MinotaurEvents : MonoBehaviour
{
    //************************** Events **************************//
    public event Action<MinotaurControl.State> onStateChange;   // Evento que salta al cambiar de estado

    //************************** Variables **************************//
    // Public    
    public MinotaurAnimation minotaurAnimation; // Script MinotaurAnimation
    public MinotaurAudio minotaurAudio;         // Script MinotaurAudio
    
    //************************** System Methods **************************//
    void Start() {
        // Agrego funciones al evento onStateChange
        onStateChange += minotaurAnimation.ChangeAnimationState;
        onStateChange += minotaurAudio.ChangePitch;
        onStateChange += minotaurAudio.Play;
    }
    
    //************************** Methods **************************//

    // Invocación del handler
    public void InvokeOnStateChange(MinotaurControl.State state) {
        onStateChange?.Invoke(state);
    }
}
