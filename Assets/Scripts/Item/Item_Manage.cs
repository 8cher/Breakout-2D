using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manage : MonoBehaviour
{
    //单例化
    public static Item_Manage Instance;
    void Awake()
    {
        Instance = this;
    }
    //道具材质的合集
    public Sprite[] Sprite_Textures = new Sprite[] { };
    //枚举：道具种类
    public enum Item_Type
    {
        Item_Longer_Paddle,
        Item_Shorter_Paddle,
        Item_Faster_Paddle,
        Item_Slower_Paddle,
        Item_Separate_Ball,
        Item_Lunch_Extra_Ball,
        Item_Faster_Ball,
        Item_Slower_Ball
    }
    //代表道具的预制体
    public Item item_Prefab;
    //父对象
    public Transform parent;

    public void Create_Item(Transform tras)
    {
        //概率性生成道具
        if (Random.value >= 0.9f)
        {
            int item_Num = Random.Range(0, 8);
            Item new_Item = Instantiate(item_Prefab, tras.position, Quaternion.identity);
            new_Item.transform.SetParent(parent, false);
            new_Item.item_Type = (Item_Type)item_Num;
            Debug.Log("生成道具种类：" + item_Num);
        }
    }
}
