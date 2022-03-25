using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // Necesario para usar TextMeshProUGUI


public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;           // Referencia a la barra de stamina en el HUD
    public GameObject player;           // Referencia al player cuya stamina es representada en la barra
    public PlayerStamina playerStamina; // Script de la stamina dentro del player

    // Start is called before the first frame update
    void Start()
    {
        playerStamina = player.GetComponent<PlayerStamina>();
        // BUG: POR MOTIVO DESCONOCIDO ESTA FUNCIÓN DEVUELVE O Y NO 100 COMO DEBERIA (ESTO PASA SOLO EN LA BUILD)
        // staminaBar.maxValue = playerStamina.GetMaxStamina();
        staminaBar.maxValue = 100f;
        staminaBar.value = playerStamina.GetStamina();
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.GetStamina();
    }
}
