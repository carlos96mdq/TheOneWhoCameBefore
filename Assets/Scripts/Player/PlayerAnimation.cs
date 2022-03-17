using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerAnimation Class
** En este scriptse actualizan los parametros del Animator de Player 
*/
public class PlayerAnimation : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    Animator playerAnimator;

    //************************** System Methods **************************//
    void Start() {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    //************************** Methods **************************//
    
    // Cambia el valor de las variables que rigen las animaciones
    public void ChangeAnimationState(PlayerControl.State state) {
        switch (state) {
            case PlayerControl.State.WALKING:
                playerAnimator.SetBool("isMoving", true);
                playerAnimator.SetBool("isRunning", false);
                break;
            case PlayerControl.State.RUNNING:
                playerAnimator.SetBool("isMoving", true);
                playerAnimator.SetBool("isRunning", true);
                break;
            case PlayerControl.State.RECOVERING:
                playerAnimator.SetBool("isTired", true);
                break;
            default:
                playerAnimator.SetBool("isMoving", false);
                playerAnimator.SetBool("isRunning", false);
                playerAnimator.SetBool("isTired", false);
                break;
        }  
    }
}
