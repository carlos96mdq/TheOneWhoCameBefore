using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* KillPlayer Class
** Maneja los triggers para indicarle al Minotauro que atrapó al Player
*/
public class KillPlayer : MonoBehaviour
{   
    //************************** Events **************************//
    void OnTriggerEnter(Collider other) {
        Debug.Log("Entra en el trigger");
        if(other.tag == "Player") {
            Debug.Log("Entra en el trigger");
            LevelOneManager.instance.LoseGame();
        }
    }
}
