using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    public static LevelOneManager instance;

    public float levelTimer;        // Timer general de la duración de la partida
    public GameObject pauseMenu;    // Menu de pausa
    public GameObject settingsMenu; // Menu de setting
    
    
    void Awake() 
    {
        // Singleton implementado
        if(instance != null && this != instance) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);    // Desactivado porque en este caso busco que solo viva en esta escena

        InitialConfig();                    // Configuración inicial del nivel                      
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer += Time.deltaTime;    // Aumento el timer general de la duración de la partida
        
        if (Input.GetKeyDown("escape")) {
            EscInput();
        }
    }

    // Configuración inicial del nivel
    void InitialConfig() {
        Cursor.lockState = CursorLockMode.Locked; // Mostrar el mouse
        levelTimer = 0f;                          // Timer del nivel 
        Time.timeScale = 1f;                      // Resumo el tiempo de calculos
        AudioListener.pause = false;              // Resumo todos los sonidos

        // Al inicio el pauseMenu y settingsMenu están desactivado
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Maneja el resultado del input esc
    void EscInput() {
        // Si el SettingsMenu está activado
        if(settingsMenu.activeSelf) {
            CloseSettings();
            OpenPause();
        }
        // Si el PauseMenu está activado
        else if(pauseMenu.activeSelf) {
            ResumeGame();
        }
        else {
            PauseGame();
        }
    }

    // Pausa el juego
    public void PauseGame() {
        Time.timeScale = 0f;                        // Paro el tiempo de calculos
        AudioListener.pause = true;                 // Paro todos los sonidos
        OpenPause();                                // Abro el PauseMenu
        Cursor.lockState = CursorLockMode.None;     // Mostrar el mouse
    }

    // Resume el juego
    public void ResumeGame() {
        Time.timeScale = 1f;                        // Resumo el tiempo de calculos
        AudioListener.pause = false;                // Resumo todos los sonidos
        ClosePause();                               // Desactiva el PauseMenu
        Cursor.lockState = CursorLockMode.Locked;   // Esconder el mouse 
    }

    // Abre el PauseMenu
    public void OpenPause() {
        pauseMenu.SetActive(true);
    }

    // Cierra el PauseMenu
    public void ClosePause() {
        pauseMenu.SetActive(false);
    }
    
    // Abre el SettingsMenu
    public void OpenSettings() {
        settingsMenu.SetActive(true);
    }

    // Cierra el SettingMenu
    public void CloseSettings() {
        settingsMenu.SetActive(false);
    }
}
