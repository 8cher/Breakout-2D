using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //道具种类
    public Item_Manage.Item_Type item_Type;
    private Vector2 temp_position;
    //委托：道具功能
    public delegate void Item_Function();
    Item_Function item_Function;
    void Start()
    {
        //根据Item_Num变量更改道具的贴图
        SpriteRenderer spRenderer = GetComponent<SpriteRenderer>();
        Sprite[] getSprite = Item_Manage.Instance.Sprite_Textures;
        spRenderer.sprite = getSprite[(int)item_Type];
        //根据Item_Num变量改变物品方法
        Item_Func.Get_Item_Function(ref item_Function, (int)item_Type);
        Debug.Log("道具获取到方法：" + item_Function);
    }

    void Update()
    {
        Item_Falldown();
    }

    //道具和板子接触后，使用item_Function函数
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tag_Paddle")
        {
            if (GM.Instance.is_Level_Playing)
            {
                item_Function();
                Sound_Effect_Manage.Instance.Playsound_Get_Item();
            }
            Debug.Log("道具触板");
            Destroy(gameObject);
        }
    }

    //道具匀速下落
    void Item_Falldown()
    {
        temp_position = transform.position;
        temp_position.y -= 5f * Time.deltaTime;
        transform.position = temp_position;
    }
}
