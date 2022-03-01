using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En este scriptse actualizan los parametros del Animator de Player 

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimation;
    PlayerMovement playerScript;    // Script de movimiento del Player, obtengo una referencia al mismo 
                                    // para utilizar sus variables publicas

    void Start()
    {
        playerAnimation = GetComponentInChildren<Animator>();
        playerScript = this.gameObject.GetComponent<PlayerMovement>();
    }

    public void ChangeIsMoving() {
        playerAnimation.SetBool("isMoving", playerScript.isMoving);
    }

    public void ChangeIsRunning(int mode) {
        playerAnimation.SetBool("isRunning", playerScript.isRunning);
    }
}
