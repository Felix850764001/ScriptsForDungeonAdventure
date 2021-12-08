using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    //玩家移动速度
    float m_speed;

    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private bool m_combatIdle = false;
    private bool m_isDead = false;

    //判断角色是否在水平\垂直移动
    private bool isMoving_h = false;
    private bool isMoving_v = false;

    //虚拟摇杆
    public Joystick joy;

    //移动的向量
    Vector2 movement;

    //Translate移动控制函数
    void MoveControlByTranslateGetAxis()
    {
        float horizontal = joy.Horizontal;
        float vertical = joy.Vertical;

        movement.x = horizontal;
        movement.y = vertical;

        if (horizontal != 0 && vertical != 0)
        {
            isMoving_h = true;
            isMoving_v = true;
        }
        else if(horizontal != 0 && vertical == 0)
        {
            isMoving_h = true;
            isMoving_v = false;
        } else if (horizontal == 0 && vertical != 0)
        {
            isMoving_h = false;
            isMoving_v = true;
        }
        else
        {
            isMoving_h = false;
            isMoving_v = false;
        }

        //设置人物朝向
        if (horizontal > 0)
            transform.localScale = new Vector3(-3f, 3f, 3f);
        else if (horizontal < 0)
            transform.localScale = new Vector3(3f, 3f, 3f);

        //设置人物移动动画
        m_animator.SetFloat("AirSpeed", 1);
        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            m_animator.SetInteger("AnimState", 2);
        }

        //用moveposition移动
        m_body2d.MovePosition(m_body2d.position + movement * m_speed * Time.fixedDeltaTime);
    }

    // Use this for initialization
    void Start()
    {
        Update_Speed();
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(isMoving_h || isMoving_v))
        {
            m_animator.SetInteger("AnimState", 0);
        }
    }

    private void FixedUpdate()
    {
        //人物移动
        MoveControlByTranslateGetAxis();
    }

    //更新玩家速度
    public void Update_Speed()
    {
        m_speed = UserInfo.Instance.Speed;
    }

}
