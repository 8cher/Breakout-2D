using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject particleObject;

    public Bricks_Manage.Brick_Color brickColor;
    private void Start()
    {
        //根据brickColor变量更改砖块的颜色
        SpriteRenderer spRenderer = GetComponent<SpriteRenderer>();
        Sprite[] getSprite = Bricks_Manage.Instance.Sprite_Textures;
        spRenderer.sprite = getSprite[(int)brickColor];
    }

    //小球撞砖块后：消除砖块、生成粒子效果、砖块计数-1，尝试生成道具
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tag_Ball")
        {
            Destroy(gameObject);
            Instantiate(particleObject, transform.position, Quaternion.identity);
            Item_Manage.Instance.Create_Item(gameObject.transform);
        }
    }
}

