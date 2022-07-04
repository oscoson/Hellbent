using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;
    public void SetMusic (float volume)
    {
        musicMixer.SetFloat("Music Volume", volume);
    }

    public void SetMaster (float volume)
    {
        musicMixer.SetFloat("Master Volume", volume);
    }

    public void SetSound (float volume)
    {
        musicMixer.SetFloat("Sounds Volume", volume);
    }



}
