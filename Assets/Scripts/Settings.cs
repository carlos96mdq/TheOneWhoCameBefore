using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    public Slider volumeSlider;             // Slider del volumen
    public ToggleGroup resolutionToggles;   // Toggles que manejan la resolución

    // Handler de los Toggles de Resolución
    public void OnScreenResolutionChangedHandled(int mode) {
        int width = 1200;
        int height = 720;

        // Choose resolution
        switch (mode)
        {   
            case 0:
                width = 800;
                height = 600;
                break;
            case 1:
                width = 1200;
                height = 720;
                break;
            case 2:
                width = 1366;
                height = 768;
                break;
            case 3:
                width = 1920;
                height = 1080;
                break;
        }

        GameManager.instance.ChangeScreenResolution(width, height);
    }

    // Handler de los Toggles de Modo de ventana
    public void OnScreenModeChangedHandled(int mode) {
        FullScreenMode screenMode = FullScreenMode.ExclusiveFullScreen;

        // Choose resolution
        switch (mode)
        {   
            case 0:
                screenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                screenMode = FullScreenMode.Windowed;
                break;
        }

        GameManager.instance.ChangeScreenMode(screenMode);
    }
    
    // Handler del Slider de Volumen
    public void OnVolumeValueChangedHandled() {
        GameManager.instance.VolumeUpdate(volumeSlider.value);
        Debug.Log("Handler OnVolumeValueChangedHandled llamado por evento OnValueChanged del Volume Slider");
        Debug.Log("Nuevo valor de volumen: " + volumeSlider.value);
    } 
}
