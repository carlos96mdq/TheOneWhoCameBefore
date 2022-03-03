using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    enum State
    {
        IDLE,
        WALKING,
        RUNNING,
        RECOVERING
    }

    State playerState;

    void Start()
    {
        StateIdle();
    }
    
    public void StateIdle() {
        playerState = State.IDLE;
    }

    public void StateWalking() {
        playerState = State.WALKING;
    }

    public void StateRuning() {
        playerState = State.RUNNING;
    }

    public void StateRecovering() {
        playerState = State.RECOVERING;
    }
}
