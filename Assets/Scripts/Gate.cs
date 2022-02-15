using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Puerta para apsar al siguiente nivel
public class Gate : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {   
        // Reinicio el nivel (ya que por ahora no tengo más niveles)
        if(other.tag == "Player") {
            GameManager.instance.WinGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
