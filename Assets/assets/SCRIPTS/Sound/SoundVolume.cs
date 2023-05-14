using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour
{
    [Header("Music")]
    public Slider musicVolume;
    public Text musicText;

    [Header("Effects")]
    public Slider effectsVolume;
    public Text effectsText;

    [Header("Mixer")]
    public AudioMixer audioMixer;

    bool isFullscreen;

    void Start()
    {
        musicVolume.onValueChanged.AddListener(SetMusicVolume);
        effectsVolume.onValueChanged.AddListener(SetEffectsVolume);

        if (PlayerPrefs.HasKey("MusicVol"))
            musicVolume.value = PlayerPrefs.GetFloat("MusicVol");
        else 
            musicVolume.value = 2f;
        if (PlayerPrefs.HasKey("SfxVol"))
            effectsVolume.value = PlayerPrefs.GetFloat("SfxVol");
        else
            effectsVolume.value = 4f;

        Screen.fullScreen = true;
        //isFullscreen = (PlayerPrefs.GetInt("Fullscreen") != 0);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        musicText.text = Mathf.Round(value).ToString();

        if(value == 0)
            audioMixer.SetFloat("MusicVolume", 0);

        PlayerPrefs.SetFloat("MusicVol", value);
        PlayerPrefs.Save();
    }

    public void SetEffectsVolume(float value)
    {
        audioMixer.SetFloat("SfxVolume", Mathf.Log10(value) * 20);
        effectsText.text = Mathf.Round(value).ToString();

        if (value == 0)
            audioMixer.SetFloat("SfxVolume", 0);

        PlayerPrefs.SetFloat("SfxVol", value);
        PlayerPrefs.Save();
    }
}
