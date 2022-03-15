using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* MinotaurControl Class
** Maneja y entrelaza a todos los scripts Minotaur y es la única clase donde se encuentra el Update()
*/
public class MinotaurControl : MonoBehaviour
{
    //************************** Types **************************//
    public enum State
    {
        IDLE,
        WALKING,
        RUNNING,
        SEARCHING
    }

    //************************** Variables **************************//
    // Public
    public MinotaurMovement minotaurMovement;   // Script de movimiento
    public MinotaurRotation minotaurRotation;   // Script de mrotación

    // Private
    State playerState;              // Indica el estado del Player
    System.Random randomTurn;       // Numero random que determina si el minotauro dobla o no
    float distanceWallDetection;    // Distancia a la que detecta un objeto y dobla
    float distancePlayerDetection;  // Distancia a la que detecta al player
    int playerLayer;                // Bitmask de la layer 9 para el Raycast 
    int obstacleLayer;              // Bitmask de la layer 7 para el Raycast
    int enemyLayer;                 // Bitmask de la layer 10 para el Raycast  

    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        distanceWallDetection = 10f;      
        distancePlayerDetection = 120f;    
        playerLayer = 1 << 8;
        obstacleLayer = 1 << 7;
        enemyLayer = 1 << 10;
        randomTurn = new System.Random((int)DateTime.Now.Ticks); 

        StateWalking();
    }

    void Update() {
        // Me muevo hacia delante
        minotaurMovement.MoveForward();

        // Realiza una busqueda del player en linea recta
        RaycastHit hit;                             // Almacena información sobre el primer collider detectado por el raycast
        // Verifico si colisiono con algo a menos de 120 unidades y si ese objeto es el player
        if(Physics.Raycast(transform.position, transform.forward, out hit, distancePlayerDetection, playerLayer + obstacleLayer) &&
           hit.collider.tag == "PlayerTrigger") {
            StateRuning();
        }
        else {
            StateWalking();
        }
    }

    //************************** Methods **************************//

    public State GetState() {
        return playerState;
    }
    
    public void StateIdle() {
        playerState = State.IDLE;
    }

    public void StateWalking() {
        playerState = State.WALKING;
    }

    public void StateRuning() {
        playerState = State.RUNNING;
    }

    public void StateSearching() {
        playerState = State.SEARCHING;
    }

    public bool IsIdle() {
        return (playerState == State.IDLE);
    }

    public bool IsWalking() {
        return (playerState == State.WALKING);
    }

    public bool IsRunning() {
        return (playerState == State.RUNNING);
    }

    public bool IsSearching() {
        return (playerState == State.SEARCHING);
    }

    //************************** Events **************************//
    
    // Entro en contacto con un Rotation Trigger
    public void OnChildTriggerEnter() {
        Debug.Log("Trigger");
        // Verifico si tengo obstaculos delante, y en caso de haber, determino hacia donde doblar
        if(Physics.Raycast(transform.position, transform.forward, distanceWallDetection, obstacleLayer)) {
            // Si la derecha está ocupada, dobla a la izquierda
            if(Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer)) {
                minotaurRotation.TurnLeft();
                OnChildTriggerEnter();  // Utilizo recursividad para evitar un callejon sin salida
            }
            // Si la izquierda está ocupada, dobla a la derecha
            else if(Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer)) {
                minotaurRotation.TurnRight();
                OnChildTriggerEnter();
            }
            // Si ambos lados están libres, dobla de manera aleatoria
            else {
                Debug.Log("Trigger random");
                if(randomTurn.Next(1, 11) <= 5) {
                    minotaurRotation.TurnRight();
                }
                else minotaurRotation.TurnLeft();
            }
        }
        // En caso de no haber verifico si hay huecos para doblar aleatoriamente
        else {
            // Veo un hueco a la derecha
            if(!Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 90) {
                minotaurRotation.TurnRight();
            }
            // Veo un hueco a la izquierda
            else if(!Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 90) {
                minotaurRotation.TurnLeft();
            }
        }     
    }


    // VER EL TEMA DE CRUZARSE CON OTRO ENEMIGO
}
