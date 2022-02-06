using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En este scriptse actualizan los parametros del Animator de Player 

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimation;

    void Start()
    {
        playerAnimation = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        playerAnimation.SetBool("isMoving", PlayerMovement.isPlayerMoving);
        playerAnimation.SetBool("isRunning", PlayerMovement.isPlayerRunning);
    }
}
