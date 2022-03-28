using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // [SerializeField] GameObject firstPersonCamera;
    // [SerializeField] GameObject thirdPersonCamera;
    [SerializeField] Transform playerCamera;

    Vector3 firstPersonView = new Vector3(0, 1.89f, 0.77f);
    Vector3 thirdPersonView = new Vector3(0, 2.40f, -4.22f);

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.localPosition = firstPersonView;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
           ChangeCamera();
        }
    }

    void ChangeCamera() {
        if(playerCamera.localPosition == firstPersonView) {
            playerCamera.localPosition = thirdPersonView;
        }
        else {
            playerCamera.localPosition = firstPersonView;
        }
    }
}
