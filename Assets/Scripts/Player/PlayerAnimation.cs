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
    Animator playerAnimation;

    //************************** System Methods **************************//
    void Start() {
        playerAnimation = GetComponentInChildren<Animator>();
    }

    //************************** Methods **************************//
    
    // Cambia el valor de las variables que rigen las animaciones
    public void ChangeAnimationState(PlayerControl.State state) {
        switch (state) {
            case PlayerControl.State.WALKING:
                playerAnimation.SetBool("isMoving", true);
                playerAnimation.SetBool("isRunning", false);
                break;
            case PlayerControl.State.RUNNING:
                playerAnimation.SetBool("isMoving", true);
                playerAnimation.SetBool("isRunning", true);
                break;
            case PlayerControl.State.RECOVERING:
                playerAnimation.SetBool("isTired", true);
                break;
            default:
                playerAnimation.SetBool("isMoving", false);
                playerAnimation.SetBool("isRunning", false);
                playerAnimation.SetBool("isTired", false);
                break;
        }  
    }
}
