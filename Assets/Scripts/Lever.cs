using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    bool isLeverActive = false;
    bool isPlayerNear = false;
    Animator anim;
    GameObject staircase;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        staircase = GameObject.Find("Staircases");
        staircase.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Está en contacto con el player
        if(isPlayerNear) {
            // Activo la palanca
            if(Input.GetKeyDown(KeyCode.E) && !isLeverActive) {
                PullDown();
                isLeverActive = true;
                staircase.SetActive(true);
            }
            // Desactivo la palanca
            else if(Input.GetKeyDown(KeyCode.E) && isLeverActive) {
                PullUp();
                isLeverActive = false;
                staircase.SetActive(false);
            }
        }
    }

    // Tira la palanca de arriba a abajo y activa el interruptor
    void PullDown() {
        anim.SetBool("isPullDown", true);
    }

    // Tira la palanca de abajo a arriba y desactiva el interruptor
    void PullUp() {
        anim.SetBool("isPullDown", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player") {
            isPlayerNear = false;
        }
    }
}
