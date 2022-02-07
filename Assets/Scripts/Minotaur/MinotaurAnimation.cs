using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAnimation : MonoBehaviour
{
    Animator minotaurAnimation;         // Animator del Minotauro 
    MinotaurMovement minotaurScript;    // Script de movimiento del Minotauro, obtengo una referencia al mismo 
                                        // para utilizar sus variables publicas
    
    // Start is called before the first frame update
    void Start()
    {
        minotaurAnimation = GetComponentInChildren<Animator>();
        minotaurScript = this.gameObject.GetComponent<MinotaurMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        minotaurAnimation.SetBool("isRunning", minotaurScript.isRunning);
    }
}
