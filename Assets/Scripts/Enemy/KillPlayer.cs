using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/* KillPlayer Class
** Maneja los triggers para indicarle al Minotauro que atrapó al Player
*/
public class KillPlayer : MonoBehaviour
{   
    //************************** Events **************************//
    void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
