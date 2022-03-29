using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Gate Class
** Maneja los triggers para detectar que el Player llegó a la puerta y pasa de nivel
*/
public class Gate : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {   
        if(other.tag == "Player") {
            LevelManager.instance.WinGame();
        }
    }
}
