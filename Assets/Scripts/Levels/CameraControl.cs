using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CameraControl Class
** Maneja la posicion de la cámara para alternar entre 1ra y 3ra persona
*/
public class CameraControl : MonoBehaviour
{
    //************************** Variables **************************//
    //Private
    [SerializeField] Transform playerCamera;
    Dictionary<string, Vector3> cameraView = new Dictionary<string, Vector3>();

    //************************** System Methods **************************//
    void Start() {
        cameraView.Add("firstPersonView", new Vector3(0, 1.89f, 0.77f));
        cameraView.Add("thirdPersonView", new Vector3(0, 2.40f, -4.22f));
    
        playerCamera.localPosition = cameraView["firstPersonView"];
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.C)) {
           ChangeCamera();
        }
    }

    //************************** Methods **************************//

    // Cambia la vista de cámara
    void ChangeCamera() {
        if(playerCamera.localPosition == cameraView["firstPersonView"]) {
            playerCamera.localPosition = cameraView["thirdPersonView"];
        }
        else {
            playerCamera.localPosition = cameraView["firstPersonView"];
        }
    }
}
