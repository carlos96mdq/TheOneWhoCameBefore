using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int width;                      // Estas tres variables manejan la resolución y modo de la pantalla
    int height;
    FullScreenMode fullscreenMode;
    
    public static GameManager instance;
    
    void Awake() 
    {
        // Singleton implementado
        if(instance != null && this != instance) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        InitialConfig();                    // Configuración inicial del nivel
    }

    // Configuración inicial del juego
    void InitialConfig() {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        width = 1200;               
        height = 720;
        fullscreenMode = FullScreenMode.ExclusiveFullScreen;
        ChangeScreen();
    }

    // Cambiar resolución y modo de pantalla
    void ChangeScreen() {
        Screen.SetResolution(width, height, fullscreenMode);
    }

    public void ChangeScreenResolution(int w, int h) {
        width = w;
        height = h;
        ChangeScreen();
    }

    public void ChangeScreenMode(FullScreenMode fs) {
        fullscreenMode = fs;
        ChangeScreen();
    }

    // Carga nueva escena/nivel
    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
    
    // Cambia el volumen general
    public void VolumeUpdate(float newVolume) {
        AudioListener.volume = newVolume;
    }

    // Sale del juego
    public void QuitGame() {
        Debug.Log("Exit game");
        // Si nos encontramos en el modo editor, para la reproducción del juego
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // Si estamos en una build del juego, directamente se cierra
        #else
            Application.Quit();
        #endif
    }
}
