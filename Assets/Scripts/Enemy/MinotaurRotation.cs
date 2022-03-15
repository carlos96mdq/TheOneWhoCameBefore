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

    // Public

    //************************** System Methods **************************//

    //************************** Methods **************************//

    // Dobla a la derecha
    public void TurnRight() {
        transform.Rotate(new Vector3(0f, 90f, 0f));
    }

    // Dobla a la izquierda
    public void TurnLeft() {
        transform.Rotate(new Vector3(0f, -90f, 0f));
    }

}
