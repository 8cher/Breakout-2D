using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float paddle_Speed;
    private float paddle_Scale;
    private Rigidbody2D rb_2D;
    private Vector2 temp_Pos;
    public GameObject ball_Prefab;
    public Transform ball_Parent;
    void Start()
    {
        //初始化板子的速度
        //板子移动速度，=0最慢，=1慢，=2正常，=3快，=4最快
        paddle_Speed = GM.Instance.paddle_Speed[GM.Instance.paddle_Speed_Level];
        Debug.Log("板子初始移动速度：" + paddle_Speed);
        //初始化板子的长度
        //板子长度，=0短，=1正常，=2长，=3最长
        paddle_Scale = GM.Instance.paddle_Scale[GM.Instance.paddle_Scale_Level];
        Debug.Log("板子初始长度：" + paddle_Scale);

        //注册事件-板子长短发生改变
        GM.Instance.Paddle_Scale_Event += Change_Paddle_Scale;
        //注册事件-板子速度发生变化
        GM.Instance.Paddle_Speed_Event += Change_Paddle_Speed;
        //注册事件-分裂球
        GM.Instance.Separate_Ball_Event += Separate_Ball;
        //注册事件-额外发射
        GM.Instance.Launch_ExtraBall_Event += Launch_Extra_Ball;

        rb_2D = GetComponent<Rigidbody2D>();
        Spawn_New_Ball();
    }

    void Update()
    {
        //用刚体给板子带来速度
        float delta_X = Input.GetAxisRaw("Horizontal");
        rb_2D.velocity = Vector2.right * delta_X * paddle_Speed;

        //限制板子移动位置
        Vector2 paddle_Position = transform.position;
        paddle_Position.x = Mathf.Clamp(paddle_Position.x, (-7f + paddle_Scale), (7f - paddle_Scale));
        transform.position = paddle_Position;
    }
    //生成新的小球
    public void Spawn_New_Ball()
    {
        temp_Pos = transform.position;
        GameObject temp_Ball = Instantiate(ball_Prefab, temp_Pos, Quaternion.identity);
        temp_Ball.transform.SetParent(ball_Parent, false);
        Debug.Log("初始生成小球");
    }
    //更改板子的长短
    void Change_Paddle_Scale(int i)
    {
        Debug.Log("板子长短修改参数" + i);
        GM.Instance.paddle_Scale_Level += i;
        Debug.Log("GM类：板子长度等级" + GM.Instance.paddle_Scale_Level);
        paddle_Scale = GM.Instance.paddle_Scale[GM.Instance.paddle_Scale_Level];
        Vector3 temp_Scale = new Vector3(paddle_Scale, 1, 1);
        gameObject.transform.localScale = temp_Scale;
        Debug.Log("板子长度发生改变，现在长度为：" + paddle_Scale);
    }
    //更改板子的速度
    void Change_Paddle_Speed(int i)
    {
        GM.Instance.paddle_Speed_Level += i;
        paddle_Speed = GM.Instance.paddle_Speed[GM.Instance.paddle_Speed_Level];
        Debug.Log("板子速度发生改变，现在速度为：" + paddle_Speed);
    }

    //额外小球
    public void Launch_Extra_Ball()
    {
        GameObject temp_Ball_0 = Instantiate(ball_Prefab, transform.position, Quaternion.identity);
        temp_Ball_0.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 1f).normalized;
        temp_Ball_0.transform.SetParent(ball_Parent, false);
        Debug.Log("额外小球1");

        GameObject temp_Ball_1 = Instantiate(ball_Prefab, transform.position, Quaternion.identity);
        temp_Ball_1.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 1f).normalized;
        temp_Ball_1.transform.SetParent(ball_Parent, false);
        Debug.Log("额外小球2");
    }

    //小球分裂
    public void Separate_Ball()
    {
        Ball temp_Ball = FindObjectOfType<Ball>();
        Vector2 temp_Ball_Pos = temp_Ball.transform.position;
        Vector2 temp_Ball_Velocity0 = temp_Ball.GetComponent<Rigidbody2D>().velocity;
        Vector2 temp_Ball_Velocity1 = AngelCalculate.GetRotatePosition2D(temp_Ball_Velocity0, 2 * Mathf.PI / 3);
        Vector2 temp_Ball_Velocity2 = AngelCalculate.GetRotatePosition2D(temp_Ball_Velocity0, -2 * Mathf.PI / 3);

        GameObject temp_Ball_1 = Instantiate(ball_Prefab, temp_Ball_Pos, Quaternion.identity);
        temp_Ball_1.GetComponent<Rigidbody2D>().velocity = temp_Ball_Velocity1;
        temp_Ball_1.transform.SetParent(ball_Parent, false);
        Debug.Log("分裂小球1");

        GameObject temp_Ball_2 = Instantiate(ball_Prefab, temp_Ball_Pos, Quaternion.identity);
        temp_Ball_2.GetComponent<Rigidbody2D>().velocity = temp_Ball_Velocity2;
        temp_Ball_2.transform.SetParent(ball_Parent, false);
        Debug.Log("分裂小球2");
    }
}