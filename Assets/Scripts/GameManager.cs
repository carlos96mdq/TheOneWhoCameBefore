using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* GameManager Class
** Controlador central del juego, Singleton
*/
public class GameManager : MonoBehaviour
{
    //************************** Variables **************************//
    // Private
    int width;                      // Estas tres variables manejan la resolución y modo de la pantalla
    int height;
    FullScreenMode fullscreenMode;
    float mouseSensibility;         // Valor de sensibilidad del mouse a la hora de controlar la camara

    // Public
    public static GameManager instance;
    
    //************************** System Methods **************************//
    void Awake() {
        // Singleton implementado
        if(instance != null && this != instance) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        InitialConfig();                    // Configuración inicial del nivel
    }

    //************************** Methods **************************//
    
    // Configuración inicial del juego
    void InitialConfig() {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        width = 1200;               
        height = 720;
        fullscreenMode = FullScreenMode.ExclusiveFullScreen;
        mouseSensibility = 1f;
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

    // Cambia la sensibilidad de la cámara
    public void SensibilityUpdate(float newSensibility) {
        mouseSensibility = newSensibility;
    }

    // Sale del juego
    public void QuitGame() {
        // Si nos encontramos en el modo editor, para la reproducción del juego
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // Si estamos en una build del juego, directamente se cierra
        #else
            Application.Quit();
        #endif
    }

    // Devuelve la sensibilidad del mouse
    public float GetMouseSensibility() {
        return mouseSensibility;
    }

    // Devuelve el número del nivel
    public int GetLevelNumber() {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
