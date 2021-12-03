using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb_2D;
    private Transform paddle_transform;
    AudioSource as_Ball;
    public static float ball_Speed;
    private Transform ball_Transform;
    private const float Reset_Y = -4f;
    private Vector2 temp_Coll_Speed;
    private Vector2 temp_Pos;
    private Vector2 temp_Velocity;
    private Vector2 direction_Vector;
    private Vector2 small_Angle_Hit = new Vector2(1, Mathf.Tan(10 * Mathf.Deg2Rad));
    private Vector2 large_Angle_Hit = new Vector2(1, Mathf.Tan(80 * Mathf.Deg2Rad));


    void Start()
    {
        //初始化球的速度
        //球移动速度，=0是最慢，=1慢，=2正常，=3快，=4最快
        ball_Speed = GM.Instance.ball_Speed[GM.Instance.ball_Speed_Level];

        //注册事件-更改球速度
        GM.Instance.Ball_Speed_Event += Change_Ball_Speed;

        rb_2D = GetComponent<Rigidbody2D>();
        as_Ball = GetComponent<AudioSource>();
        paddle_transform = FindObjectOfType<Paddle>().transform;
    }

    void Update()
    {
        if (!GM.Instance.is_Level_Playing)
        {
            //球没有发射之前，随板子左右移动
            Ball_Move_With_Paddle();

            //按下Space按键，发射球
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Launch_Ball();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //播放音效
        if (other.gameObject.tag == "Tag_Brick")
        {
            Sound_Effect_Manage.Instance.Playsound_Hit_Brick();
        }
        else if (other.gameObject.tag == "Tag_Wall")
        {
            Sound_Effect_Manage.Instance.Playsound_Hit_Wall();
        }
    }

    //判断撞击角度是否存在问题
    void HitAngleCheck()
    {
        direction_Vector = Vector2.one;
        temp_Velocity = rb_2D.velocity;
        if (temp_Velocity.x < 0)
        {
            temp_Velocity.x *= -1;
            direction_Vector.x = -1;
        }
        if (temp_Velocity.y < 0)
        {
            temp_Velocity.y *= -1;
            direction_Vector.y = -1;
        }
        float angle = Vector2.Angle(temp_Velocity, Vector2.right);
        if (angle < 10 || angle > 80)
        {
            //进行撞击角度的修正
            if (angle < 10)
            {
                temp_Velocity = small_Angle_Hit;
                Debug.Log("小角度撞击修复");
            }
            if (angle > 80)
            {
                temp_Velocity = large_Angle_Hit;
                Debug.Log("大角度撞击修复");
            }
            temp_Velocity.x *= direction_Vector.x;
            temp_Velocity.y *= direction_Vector.y;
            rb_2D.velocity = temp_Velocity;
            Debug.Log("修复后角度：" + temp_Velocity);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //判断撞击角度是否存在过大或过小的问题
        HitAngleCheck();
        //碰撞发生后，重置小球速度，防止越撞越快
        temp_Coll_Speed = rb_2D.velocity;
        rb_2D.velocity = temp_Coll_Speed.normalized * ball_Speed;
    }

    //随机发射方向，固定发射速度，修改游玩中状态
    private void Launch_Ball()
    {
        Vector2 normalized_Speed = AngelCalculate.GetRandomLaunchAngle().normalized;
        rb_2D.velocity = normalized_Speed * ball_Speed;
        GM.Instance.is_Level_Playing = true;
        Sound_Effect_Manage.Instance.Playsound_Launch_Ball();
    }

    //球随着板子左右移动
    private void Ball_Move_With_Paddle()
    {
        temp_Pos = paddle_transform.transform.position;
        temp_Pos.y = Reset_Y;
        transform.position = temp_Pos;
    }

    //更改球的速度
    void Change_Ball_Speed(int i)
    {
        GM.Instance.ball_Speed_Level += i;
        ball_Speed = GM.Instance.ball_Speed[GM.Instance.ball_Speed_Level];
        Debug.Log("球速度发生改变，现在速度为：" + ball_Speed);
    }
    void OnDestroy()
    {
        //取消注册事件-更改球速度
        GM.Instance.Ball_Speed_Event -= Change_Ball_Speed;
    }
}
