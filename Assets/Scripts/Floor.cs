using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    //检测是否有物品进入地板
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tag_Ball")
        {
            Debug.Log("小球撞地板");
        }
        else if (other.gameObject.tag == "Tag_Item")
        {
            Debug.Log("物品撞地板");
        }
        Destroy(other.gameObject);
        Debug.Log("销毁");
    }
}
