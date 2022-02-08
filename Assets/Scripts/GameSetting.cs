using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static GameSetting instance;

    static int gameNumber = 1;  // Cantidad de partidas jugadas
    static int winGames = 0;    // Cantidad de partidas ganadas
    static int loseGames = 0;   // Cantidad de partidas perdidas  
    static int resetGames = 0;  // Cantidad de partidas reiniciadas
    
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

    void Update()
    {
        // Para forzar el cierre del juego
        if (Input.GetKey("escape")) {
            Application.Quit();
            Debug.Log("Exit game");
        }
    }

    public void ShowScore() {
        Debug.Log("Esta es la partida número " + gameNumber + " del jugador");
        Debug.Log("El jugador ha ganado " + winGames + " partidas");
        Debug.Log("El jugador ha perdido " + loseGames + " partidas");
        Debug.Log("El jugador ha reiniciado " + resetGames + " partidas");
    }

    public void LoseGame() {
        Debug.Log("El jugador ha perdido la partida");
        gameNumber++;
        loseGames++;
    }

    public void WinGame() {
        Debug.Log("El jugador ha ganado la partida");
        gameNumber++;
        winGames++;
    }
}
