using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public event Action<PlayerState.State> onStateChange;   // Evento que salta al cambiar de estado
    
    public PlayerAnimation playerAnimation;                 // Script PlayerAnimation
    public PlayerAudio playerAudio;                         // Script PlayerAudio
    public PlayerState playerState;                         // Script PlayerState
    
    // Start is called before the first frame update
    void Start()
    {
        // Agrego funciones al evento onStateChange
        onStateChange += playerAnimation.ChangeAnimationState;
        onStateChange += playerAudio.ChangePitch;
    }

    // Invocación del handler
    public void InvokeOnStateChange(PlayerState.State state) {
        onStateChange?.Invoke(state);
    }

}
