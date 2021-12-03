using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manage : MonoBehaviour
{
    //保证脚本有且仅有一个
    public static Scene_Manage Instance;
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

    //记录关卡数
    private int _current_Level = 0;
    private int current_Level
    {
        get { return _current_Level; }
        set
        {
            if (value == 4)
            {
                _current_Level = -1;
                return;
            }
            else
            {
                _current_Level = value;
            }
        }
    }

    public void Next_Scene()
    {
        SceneManager.LoadScene(current_Level += 1);
        Debug.LogWarning("切换场景到：" + current_Level);
    }
}
