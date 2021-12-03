using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks_Manage : MonoBehaviour
{
    //单例化
    public static Bricks_Manage Instance;
    void Awake()
    {
        Instance = this;
    }

    //砖块材质的合集
    public Sprite[] Sprite_Textures = new Sprite[] { };
    //枚举：砖块的颜色类型
    public enum Brick_Color
    {
        Blue,
        Green,
        Purple,
        Red,
        Yellow
    }

    int brickCount;

    //在关卡开始时，统计所有的砖块数量
    void Start()
    {
        brickCount = transform.childCount;
    }
    //检查砖块数量是否为0，是否满足过关条件
    void Update()
    {
        brickCount = transform.childCount;
        Debug.Log("砖块数量" + brickCount);
        if ((transform.childCount <= 0) && !GM.Instance.is_Level_Passed)
        {
            GM.Instance.OnLevel_Clear();
            Debug.Log("过关");
        }
    }
}

