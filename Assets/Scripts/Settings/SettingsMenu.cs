using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Text txtMusic;
    public Text txtSfx;
    public Text txtSwitch;

    public void SetVolume(bool isOn)
    {
        if(isOn == true)
        {
            txtMusic.text = "ON";
            txtMusic.color = Color.green;
            audioMixer.SetFloat("musicVolume", 0);
        }
        else
        {
            txtMusic.text = "OFF";
            txtMusic.color = Color.red;
            audioMixer.SetFloat("musicVolume", -80f);
        }
    }

    public void SetVolumeFX(bool isOn)
    {
        if (isOn == true)
        {
            txtSfx.text = "ON";
            txtSfx.color = Color.green;
            audioMixer.SetFloat("sfxVolume", 0);
        }
        else
        {
            txtSfx.text = "OFF";
            txtSfx.color = Color.red;
            audioMixer.SetFloat("sfxVolume", -80f);
        }
    }

    public void SetVibrate(bool newValue)
    {
        if (newValue == true)
        {
            txtSwitch.text = "ON";
            txtSwitch.color = Color.green;
            Handheld.Vibrate();
        }
        else
        {
            txtSwitch.text = "OFF";
            txtSwitch.color = Color.red;
        }
    }
}
