using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public event Action onMovingChange;         // Evento que salta al cambiar el estado de isMoving
    public event Action<int> onRunningChange;   // Evento que salta al cambiar el estado de isRunning
    
    public PlayerAnimation playerAnimation;     // Script PlayerAnimation
    public PlayerAudio playerAudio;             // Script PlayerAudio
    
    // Start is called before the first frame update
    void Start()
    {
        // Agrego funciones al evento onMovingChange
        onMovingChange += playerAnimation.ChangeIsMoving;  

        // Agrego funciones al evento onMRunningChange
        onRunningChange += playerAnimation.ChangeIsRunning; 
        onRunningChange += playerAudio.ChangePitch;
    }

    // Invocación del evento onMovingChange
    public void InvokeOnMovingChangeEvent() {
        onMovingChange?.Invoke();
    }

    // Invocación del evento onRunningChange
    public void InvokeOnRunningChangeEvent(int mode) {
        onRunningChange?.Invoke(mode);

    }

}
