using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manage : MonoBehaviour
{
    public GameObject config_Panel;
    public void Start_Button()
    {
        Sound_Effect_Manage.Instance.Playsound_Click_Button();
        Scene_Manage.Instance.Next_Scene();
    }

    public void Quit_Button()
    {
        Sound_Effect_Manage.Instance.Playsound_Click_Button();
        Application.Quit();
    }

    public void Config_Button()
    {
        Sound_Effect_Manage.Instance.Playsound_Click_Button();
        config_Panel.SetActive(true);
    }
    public void Exit_Config()
    {
        config_Panel.SetActive(false);
    }
}
