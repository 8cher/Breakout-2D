using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GM : MonoBehaviour
{
    //单例化
    public static GM Instance;
    void Awake()
    {
        Time.timeScale = 1.0f;
        Instance = this;
    }
    public GameObject Level_Passed_Screen;

    //板子长度，=0短，=1正常，=2长，=3最长
    public float[] paddle_Scale = new float[] { 0.9f, 1f, 1.1f, 1.25f };
    //板子移动速度，=0最慢，=1慢，=2正常，=3快，=4最快
    public float[] paddle_Speed = new float[] { 4f, 4.5f, 6f, 6.75f, 7.5f };
    //球移动速度，=0是最慢，=1慢，=2正常，=3快，=4最快
    public float[] ball_Speed = new float[] { 5f, 8f, 10f, 13f, 14f };

    //板子长度
    private int _paddle_Scale_Level = 1;
    public int paddle_Scale_Level
    {
        get { return _paddle_Scale_Level; }
        set
        {
            if ((value <= -1) || (value >= 4))
            { return; }
            else
            { _paddle_Scale_Level = value; }
        }
    }
    //板子速度
    private int _paddle_Speed_Level = 2;
    public int paddle_Speed_Level
    {
        get { return _paddle_Speed_Level; }
        set
        {
            if ((value <= -1) || (value >= 5))
            { return; }
            else
            { _paddle_Speed_Level = value; }
        }
    }
    //球速度
    private int _ball_Speed_Level = 2;
    public int ball_Speed_Level
    {
        get { return _ball_Speed_Level; }
        set
        {
            if ((value <= -1) || (value >= 5))
            { return; }
            else
            { _ball_Speed_Level = value; }
        }
    }

    //状态参数：关卡是否正在游玩
    public bool is_Level_Playing = false;
    //状态参数：关卡是否正通过
    public bool is_Level_Passed = false;

    void Start()
    {
        //注册事件-过关
        Level_Clear_Event += Passed_Level;
    }

    void Update()
    {
        if (is_Level_Passed)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Scene_Manage.Instance.Next_Scene();
            }
        }
    }

    //过关时的方法：显示过关画面，慢镜头特效
    public void Passed_Level()
    {
        is_Level_Passed = true;
        Level_Passed_Effect();
        Level_Passed_Screen.SetActive(true);
    }
    //过关时的慢镜头特效
    private void Level_Passed_Effect()
    {
        Time.timeScale = 0.5f;
        Debug.Log("慢镜头时间");
        Invoke("Time_Scale_Reset", 0.5f);
    }
    //供慢镜头特效延迟调用的方法
    private void Time_Scale_Reset()
    {
        Time.timeScale = 1f;
        Debug.Log("慢镜头时间恢复");
    }

    //声明事件-板子长短发生改变
    public UnityAction<int> Paddle_Scale_Event;
    public void OnPaddle_Scale_Change(int i)
    {
        if (Paddle_Scale_Event != null)
        {
            Paddle_Scale_Event(i);
        }
    }
    //声明事件-板子速度发生变化
    public UnityAction<int> Paddle_Speed_Event;
    public void OnPaddle_Speed_Change(int i)
    {
        if (Paddle_Speed_Event != null)
        {
            Paddle_Speed_Event(i);
        }
    }
    //球速度发生变化
    public UnityAction<int> Ball_Speed_Event;
    public void OnBall_Speed_Change(int i)
    {
        if (Ball_Speed_Event != null)
        {
            Ball_Speed_Event(i);
        }
    }
    //分裂球
    public UnityAction Separate_Ball_Event;
    public void OnSeparate_Ball()
    {
        if (Separate_Ball_Event != null)
        {
            Separate_Ball_Event();
        }
    }
    //额外发射球
    public UnityAction Launch_ExtraBall_Event;
    public void OnExtra_Ball()
    {
        if (Launch_ExtraBall_Event != null)
        {
            Launch_ExtraBall_Event();
        }
    }
    //过关事件
    public UnityAction Level_Clear_Event;
    public void OnLevel_Clear()
    {
        if (Level_Clear_Event != null)
        {
            Level_Clear_Event();
        }
    }
}