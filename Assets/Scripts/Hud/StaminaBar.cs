using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;   // Referencia a la barra de stamina en el HUD
    public GameObject player;   // Referencia al player cuya stamina es representada en la barra
    PlayerStamina playerStamina;// Script de la stamina dentro del player
    
    // Start is called before the first frame update
    void Start()
    {
        playerStamina = player.GetComponent<PlayerStamina>();
        staminaBar.maxValue = playerStamina.GetMaxStamina();
        staminaBar.value = playerStamina.GetStamina();
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.GetStamina();
    }
}
