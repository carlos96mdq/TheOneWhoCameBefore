using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* RockBullet Class
** Detecta al jugador pisando la trampa y crea una roca que se dispara desde una pared a toda velocidad
*/
public class RockBullet : MonoBehaviour
{
    //************************** Variables **************************//
    //Public
    public GameObject rock;
    public AudioSource trapActivationSound;

    //Private
    Rigidbody rockRigid;

    //************************** System Methods **************************//
    void Start() {
        rock.SetActive(false);
        rockRigid = rock.GetComponent<Rigidbody>();
    }

    //************************** Events **************************//

    // El jugador pisa y activa la trampa
    void OnTriggerEnter(Collider other) {
        if(other.tag == "PlayerTrap") {
            if(!rock.activeSelf) {
                trapActivationSound.Play();
                rock.SetActive(true);
                rockRigid.AddRelativeForce(new Vector3(2500, 0, 0), ForceMode.Acceleration);
            }
        }
    }
}
