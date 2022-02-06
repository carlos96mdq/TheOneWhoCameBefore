using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAnimation : MonoBehaviour
{
    Animator minotaurAnimation; // Animator del Minotauro 
    
    // Start is called before the first frame update
    void Start()
    {
        minotaurAnimation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        minotaurAnimation.SetBool("isRunning", MinotaurMovement.isMinotaurRunning);
    }
}
