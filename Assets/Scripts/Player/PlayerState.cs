using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State
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
    
    public State GetState() {
        return playerState;
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

    public bool IsIdle() {
        return (playerState == State.IDLE);
    }

    public bool IsWalking() {
        return (playerState == State.WALKING);
    }

    public bool IsRunning() {
        return (playerState == State.RUNNING);
    }

    public bool IsRecovering() {
        return (playerState == State.RECOVERING);
    }
}
