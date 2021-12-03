using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    //保证BGM脚本有且仅有一个
    static BGM bgm;
    void Awake()
    {
        if (bgm == null)
        {
            bgm = this;
        }
        else if (bgm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
