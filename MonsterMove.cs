using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D m_body2d;
    public int m_speed = 5;

    //移动的向量
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();

        //测试移动
        //movement.x = gameObject.transform.position.x - 5;
        //movement.y = gameObject.transform.position.y + 5;

        movement.x = -0.1f;
        movement.y = 0.1f;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        anim.SetInteger("State", 1);
        //用moveposition移动
        m_body2d.MovePosition(m_body2d.position + movement * m_speed * Time.fixedDeltaTime);
    }
}
