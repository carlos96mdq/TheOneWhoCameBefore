using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerControl Class
** Maneja y entrelaza a todos los scripts Player y es la única clase donde se encuentra el Update()
*/
public class PlayerControl : MonoBehaviour
{
    //************************** Types **************************//
    public enum State
    {
        IDLE,
        WALKING,
        RUNNING,
        RECOVERING
    }

    //************************** Variables **************************//
    // Public
    public PlayerEvents playerEvents;       // Script de eventos
    public PlayerMovement playerMovement;   // Script de movimiento
    public PlayerRotation playerRotation;   // Script de rotación
    public PlayerStamina playerStamina;     // Script de stamina

    // Private
    State playerState;  // Indica el estado del Player
    int movement;       // Indica como es el movimiento del Player

    //************************** System Methods **************************//
    void Start() {
        StateIdle();
    }

    void Update() {

        // Movimiento
        // Si el Player está cansado comienza a recuperarse
        if(IsRecovering()) {
            // Si recupero la stamina suficiente dejo de estar cansado
            if(playerStamina.RecoverStamina()) {
                StateIdle();
                playerEvents.InvokeOnStateChange(GetState());
            }  
        }
        // Caso contrario verifico si se mueve
        else { 
            movement = playerMovement.Movement();
            switch (movement) {
                // Quieto
                case 0:
                    // Si anteriormente el Player no estaba quito, lo pongo quieto
                    if(!IsIdle()) {
                        StateIdle();
                        playerEvents.InvokeOnStateChange(GetState());
                    }
                    // Recupero stamina
                    playerStamina.RecoverStamina();
                    break;
                // Caminando
                case 1:
                    // Si anteriormente el Player no estaba caminando, lo pongo caminando
                    if(!IsWalking()) {
                        StateWalking();
                        playerEvents.InvokeOnStateChange(GetState());
                    }
                    playerStamina.RecoverStamina();
                    break;
                // Corriendo
                case 2:
                    if(!IsRunning()) {
                        StateRuning();
                        playerEvents.InvokeOnStateChange(GetState());
                    }

                    // Si se agota la stamina pasa a estado RECOVERING
                    if(playerStamina.ConsumeStamina()) {
                        StateRecovering();
                        playerEvents.InvokeOnStateChange(GetState());
                    }
                    break;
            }
        }

        // Rotación
        playerRotation.Rotation(); // Rotación de la camara

        // Efecto de gravedad
        playerMovement.Gravity();                                               // CORREGIR
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

    public void StateRecovering() {
        playerState = State.RECOVERING;
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

    public bool IsRecovering() {
        return (playerState == State.RECOVERING);
    }
}
