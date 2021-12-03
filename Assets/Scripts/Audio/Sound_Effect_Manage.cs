using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effect_Manage : MonoBehaviour
{
    //单例化，保证有且仅有一个
    public static Sound_Effect_Manage Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //0: Hit Brick
    //1：Hit Wall
    //2: Click Button
    //3: Launch Ball
    //4: Get Item
    public AudioClip[] audio_Clips;
    private AudioSource audio_Source;
    void Start()
    {
        audio_Source = GetComponent<AudioSource>();
    }

    public void Playsound_Hit_Brick()
    {
        audio_Source.PlayOneShot(audio_Clips[0]);
    }

    public void Playsound_Hit_Wall()
    {
        audio_Source.PlayOneShot(audio_Clips[1]);
    }

    public void Playsound_Click_Button()
    {
        audio_Source.PlayOneShot(audio_Clips[2]);
    }
    public void Playsound_Launch_Ball()
    {
        audio_Source.PlayOneShot(audio_Clips[3]);
    }
    public void Playsound_Get_Item()
    {
        audio_Source.PlayOneShot(audio_Clips[4]);
    }
}
