using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/* LevelOneManager Class
** Controlador central del primer nivel, trabjando en relación con el GameManager, Singleton
*/
public class LevelOneManager : MonoBehaviour
{
    //************************** Types **************************//
    public enum State {
        START,
        PLAY,
        PAUSE,
        WIN,
        LOSE
    }
    
    //************************** Variables **************************//
    //Private
    State levelState;                   // Estado de la aprtida actual
    ChromaticAberration chromatic;      // Post-Processing: Chomatic Aberration

    //Public
    public float levelTimer;            // Timer general de la duración de la partida
    public GameObject pauseMenu;        // Menu de pausa
    public GameObject settingsMenu;     // Menu de setting
    public GameObject controlsScreen;   // Pantalla que muestra la lista de controles
    public GameObject winScreen;        // Pantalla mostrada al terminar el nivel
    public GameObject loseScreen;       // Pantalla mostrada al perder la partida
    public AudioSource bgMusic;         // Musica ambiente
    public PostProcessVolume postProces;// Volumen del Post Processing


    public static LevelOneManager instance;
        
    //************************** System Methods **************************//
    void Awake() {
        // Singleton implementado
        if(instance != null && this != instance) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);    // Desactivado porque en este caso busco que solo viva en esta escena

        postProces.profile.TryGetSettings(out chromatic);

        InitialConfig();                    // Configuración inicial del nivel                      
    }

    void Update() {
        switch (levelState) {
            // Nivel cargado pero esperando para empezar
            case State.START:
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                    StartGame();
                }
            break;

            // Juego corriendo
            case State.PLAY:
                levelTimer += Time.deltaTime;    // Aumento el timer general de la duración de la partida
                if (Input.GetKeyDown("escape")) {
                    PauseGame();
                }
            break;

            // Juego pausado
            case State.PAUSE:
                if (Input.GetKeyDown("escape")) {
                    PauseMenu();
                }
            break;

            // Juego ganado
            case State.WIN:
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                    GameManager.instance.LoadScene(1);  // Comienza a cargar el nuevo nivel

                }
            break;

            // Juego perdido
            case State.LOSE:
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                    GameManager.instance.LoadScene(0);  // Vuelvo al menu principal
                }
            break;

        }
    }

    //************************** Methods **************************//
    
    // Configuración inicial del juego
    void InitialConfig() {
        Cursor.lockState = CursorLockMode.None; // Mostrar el mouse
        levelTimer = 0f;                        // Timer del nivel 
        Time.timeScale = 0f;                    // Empiezo con el tiempo parado
        AudioListener.pause = true;             // Freno todos los sonidos
        levelState = State.START;               // Indico el estado incial del nivel              
        ChangeChromatic(false);                 // valor inicial del chromatic aberration

        // Al inicio el pauseMenu y settingsMenu están desactivado
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    // inicio el juego
    void StartGame() {
        Cursor.lockState = CursorLockMode.Locked;   // Mostrar el mouse
        levelTimer = 0f;                            // Timer del nivel 
        Time.timeScale = 1f;                        // Empiezo con el tiempo parado
        AudioListener.pause = false;                // Freno todos los sonidos
        CloseControls();
        bgMusic.Play();
        levelState = State.PLAY;
    }

    // Pausa el juego
    public void PauseGame() {
        Time.timeScale = 0f;                        // Paro el tiempo de calculos
        AudioListener.pause = true;                 // Paro todos los sonidos
        Cursor.lockState = CursorLockMode.None;     // Mostrar el mouse
        OpenPause();                                // Abro el PauseMenu
        levelState = State.PAUSE;
    }

    // Resume el juego
    public void ResumeGame() {
        Time.timeScale = 1f;                        // Resumo el tiempo de calculos
        AudioListener.pause = false;                // Resumo todos los sonidos
        ClosePause();                               // Desactiva el PauseMenu
        Cursor.lockState = CursorLockMode.Locked;   // Esconder el mouse 
        levelState = State.PLAY;
    }

    // Maneja el resultado del input esc
    void PauseMenu() {
        // Si el SettingsMenu está activado
        if(settingsMenu.activeSelf) {
            CloseSettings();
            OpenPause();
        }
        // Si el PauseMenu está activado
        else if(pauseMenu.activeSelf) {
            ResumeGame();
        }
    }

    // Gana el nivel
    public void WinGame() {
        Time.timeScale = 0f;                        // Paro el tiempo de calculos
        AudioListener.pause = true;                 // Paro todos los sonidos
        Cursor.lockState = CursorLockMode.None;     // Mostrar el mouse
        winScreen.SetActive(true);
        levelState = State.WIN;
    }

    // Pierde el juego
    public void LoseGame() {
        Time.timeScale = 0f;                        // Paro el tiempo de calculos
        AudioListener.pause = true;                 // Paro todos los sonidos
        Cursor.lockState = CursorLockMode.None;     // Mostrar el mouse
        loseScreen.SetActive(true);
        levelState = State.LOSE;
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
    
    // Cierra el ControlsScreen
    public void CloseControls() {
        controlsScreen.SetActive(false);
    }


    // Configura el Chromatic Aberration
    public void ChangeChromatic(bool isOn) {
        if(isOn) {
            chromatic.intensity.value = 1f;
        }
        else {
            chromatic.intensity.value = 0.4f;
        }
    }
}
