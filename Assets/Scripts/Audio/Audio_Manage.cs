using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manage : MonoBehaviour
{
    public AudioMixer audioMixer;

    //BGM音量大小
    public void Change_BGM_Volume(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }
    //音效音量大小
    public void Change_SoundEffect_Volume(float volume)
    {
        audioMixer.SetFloat("Sound_Effect_Volume", volume);
    }
    //总音量大小
    public void Change_Total_Volume(float volume)
    {
        audioMixer.SetFloat("Total_Volume", volume);
    }
}
