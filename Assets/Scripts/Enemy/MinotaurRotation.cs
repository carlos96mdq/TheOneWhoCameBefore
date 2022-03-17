using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* MinotaurRotation Class
** Maneja la rotación del Minotauro
*/
public class MinotaurRotation : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    Quaternion initialRotation;  // La rotación en el momento que empieza a rotar

    // Public

    //************************** System Methods **************************//

    //************************** Methods **************************//

    // Doblar (0: a la derecha y 1: a la izquierda)
    public void Turn(float progression, int direction) {
        if(direction == 0) {
            transform.rotation = Quaternion.Lerp(initialRotation, initialRotation * Quaternion.Euler(0f, 90f, 0f), progression);
        }
        else {
            transform.rotation = Quaternion.Lerp(initialRotation, initialRotation * Quaternion.Euler(0f, -90f, 0f), progression);
        }
    }
    
    // Modifica el angulo de rotación inicial con el actual
    public void ChangeInitialRotation() {
        initialRotation = transform.rotation;
    }

}
