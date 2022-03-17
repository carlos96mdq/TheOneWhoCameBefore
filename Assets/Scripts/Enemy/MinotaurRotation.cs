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
        Quaternion actualRotation = transform.rotation;
        // transform.Rotate(new Vector3(0f, 90f, 0f));
        transform.rotation = Quaternion.Lerp(actualRotation, actualRotation * Quaternion.Euler(0f, 90f, 0f), 0.5f);
    }

    // Dobla a la izquierda
    public void TurnLeft() {
        // transform.Rotate(new Vector3(0f, -90f, 0f));
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(0f, -90f, 0f), 0.5f);

    }

}
