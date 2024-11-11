using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Scrollbar brightnessScrollbar;
    private void Start()
    {
        // Cargar los valores guardados al iniciar el menú de opciones
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f); 
        brightnessScrollbar.value = PlayerPrefs.GetFloat("Brightness", 0.5f);

        
        SetVolume(volumeSlider.value);
        SetBrightness(brightnessScrollbar.value);

        // Añadir listeners a los controles
        volumeSlider.onValueChanged.AddListener(SetVolume);
        brightnessScrollbar.onValueChanged.AddListener(SetBrightness);
    }
    //cambiamos los valores del volemen
    public void SetVolume(float volume)
    {
        
        AudioListener.volume = volume;
       
        PlayerPrefs.SetFloat("Volume", volume);
    }
    //cambiamos los valores del brillop
    public void SetBrightness(float brightness)
    {
        
        RenderSettings.ambientLight = Color.white * brightness;
       
        PlayerPrefs.SetFloat("Brightness", brightness);
    }

    private void OnDestroy()
    {
        // Guardar las preferencias cuando se cierre el menú de opciones
        PlayerPrefs.Save();
    }
}
