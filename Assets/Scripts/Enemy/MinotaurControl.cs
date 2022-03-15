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
    bool obstacle;                  // Indica si hay obstaculos
    float distanceWallDetection;    // Distancia a la que detecta un objeto y dobla
    float distancePlayerDetection;  // Distancia a la que detecta al player
    int playerLayer;                // Bitmask de la layer 9 para el Raycast 
    int obstacleLayer;              // Bitmask de la layer 7 para el Raycast
    int enemyLayer;                 // Bitmask de la layer 10 para el Raycast  

    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        obstacle = false;
        distanceWallDetection = 5.5f;      
        distancePlayerDetection = 120f;    
        playerLayer = 1 << 8;
        obstacleLayer = 1 << 7;
        enemyLayer = 1 << 10;
        randomTurn = new System.Random((int)DateTime.Now.Ticks); 

        StateWalking();
    }

    void Update() {

        // Rotación
        // Verifico si tengo obstaculos u otro enemigo delante, y en caso de haber, determino hacia donde doblar
        if(Physics.Raycast(transform.position, transform.forward, distanceWallDetection, obstacleLayer + enemyLayer)) {
            // Si la derecha está ocupada, dobla a la izquierda
            if(Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer)) {
                minotaurRotation.TurnLeft();
            }
            // Si la izquierda está ocupada, dobla a la derecha
            else if(Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer)) {
                minotaurRotation.TurnRight();
            }
            // Si ambos lados están libres, dobla de manera aleatoria
            else {
                if(randomTurn.Next(1, 11) <= 5) {
                    minotaurRotation.TurnRight();
                }
                else minotaurRotation.TurnLeft();
            }
            obstacle = true;    // Indico que hubo un obstaculo   
        }
        // En caso de no haber verifico si hay huecos para doblar aleatoriamente
        if(!obstacle) {
            // Veo un hueco a la derecha
            if(!Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 98) {
                minotaurRotation.TurnRight();
            }
            // Veo un hueco a la izquierda
            else if(!Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 98) {
                minotaurRotation.TurnLeft();
            }
        }     

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
    public void OnChildTriggerEnter() {
        Debug.Log("Hubo colision");
    }
}
