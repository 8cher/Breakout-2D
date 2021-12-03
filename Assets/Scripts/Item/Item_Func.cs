using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Item_Func
{
    //获取到物品的方法
    public static void Get_Item_Function(ref Item.Item_Function item_Function, int item_Num)
    {
        switch (item_Num)
        {
            //Item_Longer_Paddle
            case 0:
                item_Function = Item_Function_Longer_Paddle;
                break;
            //Item_Shorter_Paddle
            case 1:
                item_Function = Item_Function_Shorter_Paddle;
                break;
            //Item_Faster_Paddle
            case 2:
                item_Function = Item_Function_Faster_Paddle;
                break;
            //Item_Slower_Paddle
            case 3:
                item_Function = Item_Function_Slower_Paddle;
                break;
            //Item_Separate_Ball
            case 4:
                item_Function = Item_Function_Seperate_Ball;
                break;
            //Item_Lunch_Extra_Ball
            case 5:
                item_Function = Item_Function_Lunch_Extra_Ball;
                break;
            //Item_Faster_Ball
            case 6:
                item_Function = Item_Function_Faster_Ball;
                break;
            //Item_Slower_Ball
            case 7:
                item_Function = Item_Function_Slower_Ball;
                break;
        }
    }
    public static void Item_Function_Longer_Paddle()
    {
        Debug.Log("道具效果执行：板子变长");
        GM.Instance.OnPaddle_Scale_Change(1);

    }
    public static void Item_Function_Shorter_Paddle()
    {
        Debug.Log("道具效果执行：板子变短");
        GM.Instance.OnPaddle_Scale_Change(-1);
    }

    public static void Item_Function_Faster_Paddle()
    {
        Debug.Log("道具效果执行：板子变快");
        GM.Instance.OnPaddle_Speed_Change(1);
    }

    public static void Item_Function_Slower_Paddle()
    {
        Debug.Log("道具效果执行：板子变慢");
        GM.Instance.OnPaddle_Speed_Change(-1);
    }
    public static void Item_Function_Seperate_Ball()
    {
        Debug.Log("道具效果执行：分裂球");
        GM.Instance.OnSeparate_Ball();
    }
    public static void Item_Function_Lunch_Extra_Ball()
    {
        Debug.Log("道具效果执行：发射额外球");
        GM.Instance.OnExtra_Ball();
    }

    public static void Item_Function_Faster_Ball()
    {
        Debug.Log("道具效果执行：球变快");
        GM.Instance.OnBall_Speed_Change(1);
    }

    public static void Item_Function_Slower_Ball()
    {
        Debug.Log("道具效果执行：球变慢");
        GM.Instance.OnBall_Speed_Change(-1);
    }
}
