using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En este scriptse actualizan los parametros del Animator de Player 

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimation;
    PlayerMovement playerScript;    // Script de movimiento del Player, obtengo una referencia al mismo 
                                    // para utilizar sus variables publicas
    public PlayerState playerState; // Script que maneja el estado del Player

    void Start()
    {
        playerAnimation = GetComponentInChildren<Animator>();
        playerScript = this.gameObject.GetComponent<PlayerMovement>();
    }

    // Cambia el valor de las variables que rigen las animaciones
    public void ChangeAnimationState(PlayerState.State state) {
        switch (state)
        {
            case PlayerState.State.WALKING:
                playerAnimation.SetBool("isMoving", true);
                playerAnimation.SetBool("isRunning", false);
                break;
            case PlayerState.State.RUNNING:
                playerAnimation.SetBool("isMoving", true);
                playerAnimation.SetBool("isRunning", true);
                break;
            default:
                playerAnimation.SetBool("isMoving", false);
                playerAnimation.SetBool("isRunning", false);
                break;
        }  
    }
}
