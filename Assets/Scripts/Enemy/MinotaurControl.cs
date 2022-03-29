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
    public enum State {
        IDLE,
        ROARING,
        ROTATING,
        WALKING,
        RUNNING,
        BACKING
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
    float distanceFloorDetection;   // Distancia a la que detecta el piso
    float distancePlayerDetection;  // Distancia a la que detecta al player
    float rotationProgres;          // Rotación ya realizada
    float roarTime;                 // La duración en segundos del rugido
    float roarDuration;             // La duración máxima del rugido
    int rotationDir;                // Dirección de rotación, siendo 0 derecha y 1 izquierda
    int playerLayer;                // Bitmask de la layer 9 para el Raycast 
    int obstacleLayer;              // Bitmask de la layer 7 para el Raycast
    int enemyLayer;                 // Bitmask de la layer 10 para el Raycast 
    int groundLayer;                // Mitmark de la layer 9 para el Raycast
    bool isFirstRoar;               // Se utiliza para determinar si es el primer rugido 

    //************************** System Methods **************************//
    void Start() {
        // Definicón de variables
        isFirstRoar = true;
        distanceWallDetection = 10f;  
        distanceFloorDetection = 12f;    
        distancePlayerDetection = 120f;
        roarTime = 0f; 
        roarDuration = 3f;   
        playerLayer = 1 << 8;
        obstacleLayer = 1 << 7;
        enemyLayer = 1 << 10;
        groundLayer = 1 << 9;
        randomTurn = new System.Random((int)DateTime.Now.Ticks); 

        StateIdle();
    }

    void Update() {

        // Depende el estado prosigo
        switch (minotaurState) {

            // Para cuando arranca la primera vez
            case State.IDLE:
                // Comienzo a moverme cuando me activo
                StateRoaring();
                // StateWalking();
                // StateRuning();
                break;

            case State.ROARING:
                // Rujo durante 3 segundos
                roarTime += Time.deltaTime;
                if(roarTime > roarDuration) {
                    if(isFirstRoar) {
                        isFirstRoar = false;
                        StateWalking();
                    }
                    else {
                        StateRuning();
                    }
                    roarTime = 0f;
                }
                break;

            // Está caminando
            case State.WALKING:
                // Me muevo hacia delante (false es porque no está corriendo)
                minotaurMovement.MoveForward(false);
                // Realiza una busqueda del player en linea recta
                RaycastHit hit;                             // Almacena información sobre el primer collider detectado por el raycast
                // Verifico si colisiono con algo a menos de 120 unidades y si ese objeto es el player
                if(Physics.Raycast(transform.position, transform.forward, out hit, distancePlayerDetection, playerLayer) && hit.collider.tag == "PlayerTrigger") {
                    StateRoaring();
                }
                break;
            
            // Está corriendo. Entra en un estado de estampida que no para hasta llegar a una pared
            case State.RUNNING:
                // Me muevo hacia delante (false es porque no está corriendo)
                minotaurMovement.MoveForward(true);
                break;
            
            // Está retrocediendo
            case State.BACKING:
                // Me muevo hacia atras
                minotaurMovement.MoveBackward();
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

    public void StateRoaring() {
        minotaurState = State.ROARING;
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    // direction indica la dirección donde va a doblar, siendo 0 la derecha y 1 la izquierda
    public void StateRotating(int direction) {
        minotaurState = State.ROTATING;
        rotationDir = direction;
        rotationProgres = 0f;
        minotaurRotation.ChangeInitialRotation();
        LevelOneManager.instance.ChangeChromatic(false);
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public void StateWalking() {
        minotaurState = State.WALKING;
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public void StateRuning() {
        minotaurState = State.RUNNING;
        LevelOneManager.instance.ChangeChromatic(true);
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public void StateBacking() {
        minotaurState = State.BACKING;
        LevelOneManager.instance.ChangeChromatic(false);
        minotaurEvents.InvokeOnStateChange(GetState());
    }

    public bool IsIdle() {
        return (minotaurState == State.IDLE);
    }

    public bool IsRoaring() {
        return (minotaurState == State.ROARING);
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

    public bool IsBacking() {
        return (minotaurState == State.BACKING);
    }

    //************************** Events **************************//
    
    // Entro en contacto con un Rotation Trigger
    public void OnChildTriggerEnter() {
        Debug.Log("Trigger del minotauro activado");
        // Depende el nivel, dependa el desenlace
        if(GameManager.instance.GetLevelNumber() == 3) {
            // La dirección va a estar determinada por la dirección hacia donde mira + un vector negativo en y para mirar para abajo en diagonal
            Vector3 dir_forward = transform.forward + new Vector3(0f, -0.63f, 0f);
            dir_forward = dir_forward.normalized;    
            Vector3 dir_right = transform.right + new Vector3(0f, -0.63f, 0f);
            dir_right = dir_right.normalized;    
            // Verifico si tengo piso delante, y en caso de no haber, determino hacia donde doblar
            if(!Physics.Raycast(transform.position, dir_forward, distanceFloorDetection, groundLayer)) {
                // Si a la derecha no hay piso, dobla a la izquierda
                if(!Physics.Raycast(transform.position, dir_right, distanceFloorDetection, groundLayer)) {
                    StateRotating(1);
                }
                // Si a la izquierda no hay piso, dobla a la derecha
                else if(!Physics.Raycast(transform.position, -dir_right, distanceFloorDetection, groundLayer)) {
                    StateRotating(0);
                }
                // Si en ambos lados hay piso, dobla de manera aleatoria
                else {
                    StateRotating(randomTurn.Next(0, 2));
                }
            }
            // En caso de haber piso y estar caminando, verifico si hay pisos a los costados para doblar aleatoriamente
            else if(IsWalking()) {
                // Veo un piso a la derecha
                if(Physics.Raycast(transform.position, dir_right, distanceFloorDetection, groundLayer) && randomTurn.Next(100) > 90) {
                    StateRotating(0);
                }
                // Veo un piso a la izquierda
                else if(Physics.Raycast(transform.position, -dir_right, distanceFloorDetection, groundLayer) && randomTurn.Next(100) > 90) {
                    StateRotating(1);
                }
            }     
        }
        // Esta verificación se hace en todos los niveles
        // Verifico si tengo obstaculos delante, y en caso de haber, determino hacia donde doblar
        if(Physics.Raycast(transform.position, transform.forward, distanceWallDetection, obstacleLayer + enemyLayer)) {
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
        else if(IsWalking() && !(GameManager.instance.GetLevelNumber() == 3)) {
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

    // El Controler Character el Minotauro colisiona contra un collider o un controller character
    void OnControllerColliderHit(ControllerColliderHit hit) {
        Debug.Log("Choca contra pared");
        if(!IsBacking()) {
            Debug.Log("Retrocede");
            StateBacking();
        }
    }
}
