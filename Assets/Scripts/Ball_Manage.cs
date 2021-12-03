using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Manage : MonoBehaviour
{
    //单例化
    public static Ball_Manage Instance;
    void Awake()
    {
        Instance = this;
    }

    private int ballCount;
    void Start()
    {
        ballCount = transform.childCount;
    }

    //查询子类数量
    //如果最后一个小球被销毁，退出游玩中状态
    //在过关后，小球掉落后不再重新生成
    void Update()
    {
        ballCount = transform.childCount;
        Debug.Log("弹球数量" + ballCount);

        if (transform.childCount <= 0 && GM.Instance.is_Level_Playing)
        {
            GM.Instance.is_Level_Playing = false;
            if (!GM.Instance.is_Level_Passed)
            {
                FindObjectOfType<Paddle>().Spawn_New_Ball();
            }
        }
    }
}
