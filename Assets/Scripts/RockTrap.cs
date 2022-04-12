using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* RockTrap Class
** Detecta al jugador pisando la trampa y crea la roca que cae al jugador
*/
public class RockTrap : MonoBehaviour
{
    //************************** Variables **************************//
    //Public
    public GameObject rock;
    public AudioSource trapActivationSound;


    //************************** System Methods **************************//
    void Start() {
        rock.SetActive(false);
    }

    //************************** Events **************************//

    // El jugador pisa y activa la trampa
    void OnTriggerEnter(Collider other) {
        if(other.tag == "PlayerTrap") {
            if(!rock.activeSelf) {
                trapActivationSound.Play();
                rock.SetActive(true);
            }
        }
    }
}
