using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinotaurMovement : MonoBehaviour
{   
    public bool isRunning = false;                  // Indica si el Minotauro está corriendo o no, es usada por otros scripts
    public float movementSpeed = 7f;                // Velocidad de movimiento
    public float runningFactor = 3f;                // Indica en cuantas veces aumenta la velocidad al correr
    public float distanceWallDetection = 5.5f;      // Distancia a la que detecta un objeto y dobla
    public float distancePlayerDetection = 120f;    // Distancia a la que detecta al player
   
    int mode = 0;                                   // El estado en el que se encuentra el minotauro:
                                                    // 0: Buscando, 1: Persigiendo
    int playerLayer = 1 << 8;                       // Bitmask de la layer 9 para el Raycast 
    int obstacleLayer = 1 << 7;                     // Bitmask de la layer 7 para el Raycast    
    Vector3 vectorCorrection = new Vector3 (0f, -3f, 0f);  // Vector para lacorrección de altura del Raycast con el player               
    CharacterController controller;
    System.Random randomTurn;                       // Numero random que determina si el minotauro dobla o no

    void Start()
    {
        controller = GetComponent<CharacterController>();
        randomTurn = new System.Random((int)DateTime.Now.Ticks); 
    }

    // Update is called once per frame
    void Update()
    {
        // El actuar del Minotauro está determinado por una maquina de estados
        switch (mode) {
            case 0:
                SearchingMode();
                break;
            
            case 1:
                ChasingMode();
                break;
        }
    }

    // Estado en el cual el Minotauro se encuentra caminando en el laberinto sin rumbo fijo
    void SearchingMode() {
        TurnControl();  // Verifico si hay obstaculos, y en su caso, doblo
        MoveForward();  // Si no hay obstaculos, sigo caminando
        PlayerSearch(); // Verifico si el Player se encuentra a almenos 120 unidades (4 bloques)
    }

    void ChasingMode() {
        CheckObstacles();   // Verifico si no tengo unobstaculo delante, y en caso de sí tenerlo, dobla
        MoveForward();  // Si no hay obstaculos, sigo caminando
        PlayerSearch();     // Verifico si el Player se encuentra a almenos 120 unidades (4 bloques)
    }

    // Realiza una busqueda del player en linea recta
    void PlayerSearch() {
        RaycastHit hit; // Almacena información sobre el primer collider detectado por elraycast
        // Verifico si colisiono con algo a menos de 120 unidades y si ese objeto es el player
        if( Physics.Raycast(transform.position, transform.forward, out hit, distancePlayerDetection, playerLayer + obstacleLayer) &&
            hit.collider.tag == "PlayerTrigger") {
            mode = 1;                   // Cambio al ChasingMode
            isRunning = true;   // En el ChasingMode el Minotauro corre
        }
        else {
            mode = 0;                   // Cambio al SearchingMode
            isRunning = false;
        }
    }

    // Maneja la rotación del Minotauro contemplando desviaciones aleatorias
    void TurnControl() {
        // Verifico por obstaculos, y en caso de no haber verifico si hay huecos para doblar aleatoriamente
        if(!CheckObstacles()) {
            // Veo un hueco a la derecha
            if(!Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 98) {
                TurnRight();
            }
            // Veo un hueco a la izquierda
            else if(!Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 98) {
                TurnLeft();
            }
        }   
    }

    // Verifico si tengo obstaculos delante y en caso de haber determino hacia donde doblar
    bool CheckObstacles() {
        bool obstacle;
        // Si llega a un obstaculo
        if(Physics.Raycast(transform.position, transform.forward, distanceWallDetection, obstacleLayer)) {
            // Si la derecha está ocupada, dobla a la izquierda
            if(Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer)) {
                TurnLeft();
            }
            // Si la izquierda está ocupada, dobla a la derecha
            else if(Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer)) {
                TurnRight();
            }
            // Si ambos lados están libres, dobla de manera aleatoria
            else {
                if(randomTurn.Next(1, 11) <= 5) {
                    TurnRight();
                }
                else TurnLeft();
            }
            obstacle = true;    // Indico que hubo un obstaculo   
        }
        else {
            obstacle = false;   // Indico que no hubo un obstaculo  
        }
        return obstacle;
    }

    // Avanza para adelante
    void MoveForward() {
        // Si está corriendo, aumenta la velocidad
        if(isRunning) {
            controller.Move(transform.forward * movementSpeed * runningFactor * Time.deltaTime);
        }
        else {
            controller.Move(transform.forward * movementSpeed * Time.deltaTime);
        }
    }

    // Funciones para doblar
    // Dobla a la derecha
    void TurnRight() {
        transform.Rotate(new Vector3(0f, 90f, 0f));
    }
    // Dobla a la izquierda
    void TurnLeft() {
        transform.Rotate(new Vector3(0f, -90f, 0f));
    }
}
