using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    const float consumeStaminaFactor = 10f; // Indica el factor en el cual baja la stamina
    const float recoverStaminaFactor = 5f;  // Indica el factor en el cual sube la stamina      
    const float maxStamina = 100f;          // Indica la stamina máxima
    const float recoverTime = 10f;          // El tiempo en segundos que tarda en recuperarse para poder
                                            // volver a moverse si la stamina llegó a 0
    float stamina = 100f;                   // Indica la stamina actual
    bool exhausted = false;                 // Devuelve true si se encuentra exhausto

    // Devuelve el valor actual de stamina
    public float GetStamina() {
        return stamina;
    }

    // Devuelve el estadode exhasuto
    public bool GetExhasutedState() {
        return exhausted;
    }

    // Devuelve el recoverTime
    public float GetRecoverTime() {
        return recoverTime;
    }

    // Devuelve el maxStamina
    public float GetMaxStamina() {
        return maxStamina;
    }
    
    // Reduce el valor de stamina actual
    // Devuelve true si el personaje se encuentra exausto (stamina <= 0)
    public void ConsumeStamina() {
        if(stamina > 0) {
            stamina -= Time.deltaTime * consumeStaminaFactor;
        }
        else{
            exhausted = true;
        }
    }

    // Aumenta el valor de stamina actual
    public void RecoverStamina() {
        if(stamina < maxStamina) {
            stamina += Time.deltaTime * recoverStaminaFactor;
        }
        if(stamina > recoverTime && exhausted) {
            exhausted = false;
        }
    }
}
