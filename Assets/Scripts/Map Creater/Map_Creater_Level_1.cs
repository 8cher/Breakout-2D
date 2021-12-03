using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Creater_Level_1 : MonoBehaviour
{
    //砖块的预制体
    public Bricks Brick_Prefab;
    //父对象
    public Transform parent;
    //砖块的行列数
    public int Row_Number = 5;
    public int Column_Number = 12;
    //砖块间的缝隙大小
    public float Gap_Height = 0f;
    public float Gap_Width = 0f;
    //游戏区域大小
    private const float GAMEZONE_WIDTH = 15f;
    private const float GAMEZONE_HEIGHT = 5f;
    Bricks temp_Brick;

    void Start()
    {
        //计算初始化X\Y距离边界的位置
        float Initial_X = (GAMEZONE_WIDTH - Column_Number - (Column_Number - 1) * Gap_Width) * 0.5f + 0.5f;
        float Initial_Y = (GAMEZONE_HEIGHT - Row_Number * 0.5f - (Row_Number - 1) * Gap_Height) * 0.5f + 0.25f;
        //存储砖块位置的临时变量
        Vector2 temp_Brick_Pos = Vector2.zero;
        //生成砖块的双重循环
        for (int i = 0; i < Row_Number; i++)
        {
            for (int j = 0; j < Column_Number; j++)
            {
                temp_Brick_Pos = Calculate_Pos(j, i, Initial_X, Initial_Y);
                temp_Brick = Instantiate(Brick_Prefab, temp_Brick_Pos, Quaternion.identity);
                temp_Brick.transform.SetParent(parent, false);
                temp_Brick.brickColor = (Bricks_Manage.Brick_Color)i;
            }
        }
    }
    private Vector2 Calculate_Pos(int j, int i, float Initial_X, float Initial_Y)
    {
        //计算每个砖块的位置
        float x = Initial_X + j * (1 + Gap_Width) - 0.5f * GAMEZONE_WIDTH;
        float y = Initial_Y + i * (0.5f + Gap_Height);
        return (new Vector2(x, y));
    }
}