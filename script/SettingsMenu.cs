using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public void Awake()
    {
        if (!PlayerPrefs.HasKey("IsGameMenu"))
        {
            PlayerPrefs.SetInt("IsGameMenu", 1);
            PlayerPrefs.Save();
            Debug.Log("IsGameMenu = " + PlayerPrefs.GetInt("IsGameMenu"));
        }
        else
        {

            PlayerPrefs.SetInt("IsGameMenu", 1);
            Debug.Log("IsGameMenu = " + PlayerPrefs.GetInt("IsGameMenu"));
        }
        // 1
        if (!PlayerPrefs.HasKey("VolumeMemory"))
        {
            PlayerPrefs.SetFloat("VolumeMemory", 0);
            PlayerPrefs.Save();

            SetVolume(PlayerPrefs.GetInt("VolumeMemory"));
            Debug.Log("VolumeMemory created");
        }
        // 2
        else
        {
            SetVolume(PlayerPrefs.GetInt("VolumeMemory"));
            Debug.Log("VolumeMemory Loaded");
        }
        if (!PlayerPrefs.HasKey("IsFullScreenMemory"))
        {
            PlayerPrefs.SetInt("IsFullScreenMemory", 1);
            PlayerPrefs.Save();
            if (PlayerPrefs.GetInt("IsFullScreenMemory") == 1)
            {
                SetFullScreen(true);
            }
            else
            {
                SetFullScreen(false);
            }
            Debug.Log("VolumeMemory created");
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("IsFullScreenMemory") == 1)
            {
                SetFullScreen(true);
            }
            else
            {
                SetFullScreen(false);
            }
            Debug.Log("VolumeMemory Loaded");
        }
       
    }

    private void Start()
    {
        resolutions = Screen.resolutions;
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("VolumeMemory", volume);
        PlayerPrefs.Save();
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
