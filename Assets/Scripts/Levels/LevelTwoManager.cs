using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* LevelOneManager Class
** Controlador central del primer nivel, trabjando en relación con el GameManager, Singleton
*/
public class LevelTwoManager : LevelManager
{         
    //************************** System Methods **************************//
    protected override void Awake() {
        base.Awake();           // Configuración inicial del nivel                      
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
                    GameManager.instance.LoadScene(0);  // Comienza a cargar el nuevo nivel
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
}
