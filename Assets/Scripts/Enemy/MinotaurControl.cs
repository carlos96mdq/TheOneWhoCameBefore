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
        ROTATING,
        WALKING,
        RUNNING,
        SEARCHING
    }

    //************************** Variables **************************//
    // Public
    public MinotaurEvents minotaurEvents;       // Script de eventos
    public MinotaurMovement minotaurMovement;   // Script de movimiento
    public MinotaurRotation minotaurRotation;   // Script de mrotación

    // Private
    State minotaurState;            // Indica el estado del Minotaur
    System.Random randomTurn;       // Numero random que determina si el minotauro dobla o no
    float distanceWallDetection;    // Distancia a la que detecta un objeto y dobla
    float distancePlayerDetection;  // Distancia a la que detecta al player
    float rotationProgres;          // Rotación ya realizada
    int rotationDir;                // Dirección de rotación, siendo 0 derecha y 1 izquierda
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

        StateIdle();
    }

    void Update() {

        // Depende el estado prosigo
        switch (minotaurState) {

            // Para cuando arranca la primera vez
            case State.IDLE:
                // Comienzo a moverme cuando me activo
                StateWalking();
                // StateRuning();
                break;

            // Está caminando
            case State.WALKING:
                // Me muevo hacia delante (false es porque no está corriendo)
                minotaurMovement.MoveForward(false);
                // Realiza una busqueda del player en linea recta
                RaycastHit hit;                             // Almacena información sobre el primer collider detectado por el raycast
                // Verifico si colisiono con algo a menos de 120 unidades y si ese objeto es el player
                if(Physics.Raycast(transform.position, transform.forward, out hit, distancePlayerDetection, playerLayer) && hit.collider.tag == "PlayerTrigger") {
                    StateRuning();
                }
                break;
            
            // Está corriendo. Entra en un estado de estampida que no para ahsta llegar a una pared
            case State.RUNNING:
                // Me muevo hacia delante (false es porque no está corriendo)
                minotaurMovement.MoveForward(true);
                break;
            
            // Está doblando
            case State.ROTATING:
                // Aumento el progreso de rotación, la escala seria cuanta progresión por segundo
                // rotationProgres += 0.5f * Time.deltaTime;
                rotationProgres += 0.5f * Time.deltaTime;
                // Si se llega al fin del progreso
                if(rotationProgres >= 1.0f) {
                    rotationProgres = 1.0f;
                    minotaurRotation.Turn(rotationProgres, rotationDir);
                    StateWalking();
                    OnChildTriggerEnter();  // Esto es importante, lo utilizo para verificar que aunque doble no siga teniendo obstaculos
                }
                else {
                    minotaurRotation.Turn(rotationProgres, rotationDir);
                }
                break;
        }
    }

    //************************** Methods **************************//

    public State GetState() {
        return minotaurState;
    }
    
    public void StateIdle() {
        minotaurState = State.IDLE;
    }

    // direction indica la dirección donde va a doblar, siendo 0 la derecha y 1 la izquierda
    public void StateRotating(int direction) {
        minotaurState = State.ROTATING;
        rotationDir = direction;
        rotationProgres = 0f;
        minotaurRotation.ChangeInitialRotation();
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public void StateWalking() {
        minotaurState = State.WALKING;
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public void StateRuning() {
        minotaurState = State.RUNNING;
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public void StateSearching() {
        minotaurState = State.SEARCHING;
    }

    public bool IsIdle() {
        return (minotaurState == State.IDLE);
    }

    public bool IsRotating() {
        return (minotaurState == State.ROTATING);
    }

    public bool IsWalking() {
        return (minotaurState == State.WALKING);
    }

    public bool IsRunning() {
        return (minotaurState == State.RUNNING);
    }

    public bool IsSearching() {
        return (minotaurState == State.SEARCHING);
    }

    //************************** Events **************************//
    
    // Entro en contacto con un Rotation Trigger
    public void OnChildTriggerEnter() {
        // Verifico si tengo obstaculos delante, y en caso de haber, determino hacia donde doblar
        if(Physics.Raycast(transform.position, transform.forward, distanceWallDetection, obstacleLayer)) {
            // Si la derecha está ocupada, dobla a la izquierda
            if(Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer)) {
                StateRotating(1);
            }
            // Si la izquierda está ocupada, dobla a la derecha
            else if(Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer)) {
                StateRotating(0);
            }
            // Si ambos lados están libres, dobla de manera aleatoria
            else {
                StateRotating(randomTurn.Next(0, 2));
            }
        }
        // En caso de no haber obstaculo y estar caminando, verifico si hay huecos para doblar aleatoriamente
        else if(IsWalking()) {
            // Veo un hueco a la derecha
            if(!Physics.Raycast(transform.position, transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 90) {
                StateRotating(0);
            }
            // Veo un hueco a la izquierda
            else if(!Physics.Raycast(transform.position, -transform.right, distanceWallDetection * 2, obstacleLayer) && randomTurn.Next(100) > 90) {
                StateRotating(1);
            }
        }     
    }

    //************************** Courutines **************************//

    // Corutina para rotar lentamente
    IEnumerator Rotation() {
        yield return null;
    }


    // VER EL TEMA DE CRUZARSE CON OTRO ENEMIGO
}
