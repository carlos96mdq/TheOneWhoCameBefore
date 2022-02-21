using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    public GameObject settingMenu;
    public GameObject loadingScreen;
    
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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            EscInput();
        }
    }

    // Configuración inicial del nivel
    void InitialConfig() {
        Cursor.lockState = CursorLockMode.None; // Mostrar el mouse 
        Time.timeScale = 1f;                    // Resumo el tiempo de calculos
        AudioListener.pause = false;            // Resumo todos los sonidos

        // Al inicio el menu de Setting y la LoadingScreen se encuentran desactivadas
        settingMenu.SetActive(false);
        loadingScreen.SetActive(false);
    }
    
    
    // Maneja el resultado del input esc
    void EscInput() {
        // Si el Setting Menu está activado
        if(settingMenu.activeSelf) {
            settingMenu.SetActive(false);
        }
        // Si no, sale del juego
        else {
            GameManager.instance.QuitGame();
        }
    }

    // Abre el Setting Menu
    public void OpenSettingMenu() {
        settingMenu.SetActive(true);
    }

    // Activa la LoadingScreen
    public void ActiveLoadingScreen() {
        loadingScreen.SetActive(true);
    }
}
