using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerStamina Class
** Se encarga de manejar la stamina del Player 
*/
public class PlayerStamina : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    float consumeStaminaFactor; // Indica el factor en el cual baja la stamina
    float recoverStaminaFactor; // Indica el factor en el cual sube la stamina      
    float maxStamina;           // Indica la stamina máxima
    float recoverTime;          // El tiempo en segundos que tarda en recuperarse para poder
                                // volver a moverse si la stamina llegó a 0
    float stamina = 100f;       // Indica la stamina actual

    // Public
    public CharacterConstants constants;    // Constantes                      

    //************************** System Methods **************************//
    void Start() {
        consumeStaminaFactor =  constants.consumeStaminaFactor;
        recoverStaminaFactor = constants.recoverStaminaFactor;
        maxStamina = constants.maxStamina;           
        recoverTime = constants.recoverTime;          
    }

    //************************** Methods **************************//

    // Devuelve el valor actual de stamina
    public float GetStamina() {
        return stamina;
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
    // Si la stamina se agota devuelve true
    public bool ConsumeStamina() {
        if(stamina > 0) {
            stamina -= Time.deltaTime * consumeStaminaFactor;
            return false;
        }
        else{
            stamina = 0;
            return true;
        }
    }

    // Aumenta el valor de stamina actual
    // Si la stamina se recupera lo suficiente devuelve true
    public bool RecoverStamina() {
        if(stamina < maxStamina) {
            stamina += Time.deltaTime * recoverStaminaFactor;
            if(stamina > recoverTime) {
                return true;
            }
            return false;            
        }
        return false;
    }
}
