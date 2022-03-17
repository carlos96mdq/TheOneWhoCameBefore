using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* MinotaurAnimation Class
** En este scriptse actualizan los parametros del Animator de Minotaur 
*/
public class MinotaurAnimation : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    Animator minotaurAnimator;         // Animator del Minotauro 
    
    //************************** System Methods **************************//
    void Start() {
        minotaurAnimator = GetComponentInChildren<Animator>();
    }

    //************************** Methods **************************//
        // Cambia el valor de las variables que rigen las animaciones
    public void ChangeAnimationState(MinotaurControl.State state) {
        switch (state) {
            case MinotaurControl.State.WALKING:
                minotaurAnimator.SetBool("isRotating", false);
                minotaurAnimator.SetBool("isRunning", false);
                break;
            case MinotaurControl.State.RUNNING:
                minotaurAnimator.SetBool("isRotating", false);
                minotaurAnimator.SetBool("isRunning", true);
                break;
            case MinotaurControl.State.ROTATING:
                minotaurAnimator.SetBool("isRotating", true);
                minotaurAnimator.SetBool("isRunning", false);
                break;
            default:
                minotaurAnimator.SetBool("isRotating", false);
                minotaurAnimator.SetBool("isRunning", false);
                break;
        }  
    }

}
