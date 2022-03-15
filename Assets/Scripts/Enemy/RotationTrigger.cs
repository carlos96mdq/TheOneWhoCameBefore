using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* RotationTrigger Class
** Maneja los triggers para indicarle al Minotauro si doblar
*/
public class RotationTrigger : MonoBehaviour
{    
    //************************** Variables **************************//
    // Private
    MinotaurControl minotaurControl;

    //************************** System Methods **************************//
    void Start() {
        minotaurControl = GetComponentInParent<MinotaurControl>();
    }
    //************************** Events **************************//
    void OnTriggerEnter(Collider other) {
        minotaurControl.OnChildTriggerEnter();
    }
}
