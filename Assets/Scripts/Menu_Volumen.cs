using UnityEngine;
using UnityEngine.UI;

public class Menu_Volumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public GameObject imagenMute;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor) 
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute() 
    {
        if (sliderValue == 0) imagenMute.SetActive(true);

        else imagenMute.SetActive(false);
    }
}
