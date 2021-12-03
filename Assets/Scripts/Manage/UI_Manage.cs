using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manage : MonoBehaviour
{
    //单例化
    public static UI_Manage Instance;
    void Awake()
    {
        Instance = this;
    }
}
