using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// El siguiente script se utliza para que al tocar el Minotauro al Player el mismo sea atrapado

public class KillPlayer : MonoBehaviour
{   
    // En caso de atrapar al player, este último pierde
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Player") {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
