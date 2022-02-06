using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject firstPersonCamera;
    [SerializeField] GameObject thirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
           ChangeCamera();
        }
    }

    void ChangeCamera() {
        firstPersonCamera.SetActive(!firstPersonCamera.activeInHierarchy);
    }
}
