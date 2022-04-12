using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/* Settings Class
** Controla los eventos producidos por modificar parametros en el menu de settings
*/
public class Settings : MonoBehaviour
{
    //************************** Variables **************************//
    //Private
    int [][]resolutions = {
        new int [] {800, 600},
        new int [] {1200, 720},
        new int [] {1366, 768},
        new int [] {1920, 1080},
    };
    
    // Public
    public Slider volumeSlider;             // Slider del volumen
    public Slider sensibilitySlider;        // Slider de la sensibilidad de la cámara
    public ToggleGroup resolutionToggles;   // Toggles que manejan la resolución
    public PlayerRotation playerRotation;   // Script de rotación de la camara del Player

    //************************** Events **************************//

    // Handler de los Toggles de Resolución de pantalla
    public void OnScreenResolutionChangedHandled(int mode) {
        int width = resolutions[mode][0];
        int height = resolutions[mode][1];
        
        // int width = 1200;
        // int height = 720;

        // // Choose resolution
        // switch (mode)
        // {   
        //     case 0:
        //         width = 800;
        //         height = 600;
        //         break;
        //     case 1:
        //         width = 1200;
        //         height = 720;
        //         break;
        //     case 2:
        //         width = 1366;
        //         height = 768;
        //         break;
        //     case 3:
        //         width = 1920;
        //         height = 1080;
        //         break;
        // }

        GameManager.instance.ChangeScreenResolution(width, height);
    }

    // Handler de los Toggles de Modo de ventana
    public void OnScreenModeChangedHandled(int mode) {
        FullScreenMode screenMode = FullScreenMode.ExclusiveFullScreen;

        // Choose resolution
        switch (mode)
        {   
            case 0:
                screenMode = FullScreenMode.Windowed;
                break;
            case 1:
                screenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }

        GameManager.instance.ChangeScreenMode(screenMode);
    }
    
    // Handler del Slider de Volumen
    public void OnVolumeValueChangedHandled() {
        GameManager.instance.VolumeUpdate(volumeSlider.value);
        Debug.Log("Nuevo valor de volumen: " + volumeSlider.value);
    }

    // Handler del Slider de Sensibilidad de la camara
    public void OnSensibilityValueChangedHandled() {
        GameManager.instance.SensibilityUpdate(sensibilitySlider.value);
        if(playerRotation) {    // Este if solo se ejecuta si se encuentra una referencia a la cámara del Player
            playerRotation.ChangeSensibility(sensibilitySlider.value);
        }
        Debug.Log("Nuevo valor de la sensibilidad: " + sensibilitySlider.value);
    }
}
