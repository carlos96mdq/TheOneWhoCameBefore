using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    }

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
    
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
