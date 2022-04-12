using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* RockAudio Class
** Al colisionar, emite sonido
*/
public class RockAudio : MonoBehaviour
{
    //************************** Variables **************************//
    //Private
    AudioSource rockSound;

    //************************** System Methods **************************//
    void Start() {
        rockSound = GetComponent<AudioSource>();
    }

    //************************** Events **************************//

    // Al chocar la roca
    void OnCollisionEnter(Collision other) {
        rockSound.Play();    
    }
}
