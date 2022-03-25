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
        // En caso de chocarme con otro Minotauro, uno debe morir para que no se traben
        if(other.tag == "Enemy") {
            Destroy(other.gameObject);  
        }
        else {
            LevelOneManager.instance.LoseGame();
        }
    }
}
