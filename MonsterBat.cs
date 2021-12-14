using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBat : Monster
{
    public Transform[] movePosition;

    //判断当前要巡逻的下一个点
    private int pos = 0;

    //临时变量，用来记录剩余停留时间
    private float wait;

    //临时变量， 用来记录怪物攻击周期剩余时间
    private float tempAttack;

    //判断当前是否在追踪玩家
    private bool isEnmity;

    //玩家临时坐标，用于追踪玩家中心位置
    private Vector3 temp;

    private Rigidbody2D m_rigidbody2D;
    private Animator anim;
    private Transform playerTransForm;
    private PolygonCollider2D collider2D;

    new void Start()
    {
        isEnmity = false;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        playerTransForm = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = transform.Find("Bat").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
        wait = waitTime;
        tempAttack = 0;
    }

    new void Update()
    {
        if (health <= 0) Death();
        else {
            if (!isEnmity) Patrol();
            else Enmity();
        }
    }

    new void Patrol()
    {
        //控制动画朝向
        if (movePosition[pos].position.x > transform.position.x)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else transform.localScale = new Vector3(1f, 1f, 1f);
        transform.position =
            Vector2.MoveTowards(transform.position, movePosition[pos].position, speed * Time.deltaTime);
        if (playerTransForm != null) {
            //判断玩家是否进入警戒范围
            temp = playerTransForm.position;
            temp.y += 1.5f;
            if (Vector2.Distance(transform.position, temp) <= warningRange) {
                isEnmity = true;
                return;
            }
        }

        if (Vector2.Distance(transform.position, movePosition[pos].position) < Mathf.Epsilon) {
            if (wait <= 0) {
                pos++;
                if (pos == movePosition.Length) pos = 0;
                wait = waitTime;
            }
            else {
                wait -= Time.deltaTime;
            }
        }
    }


    new void Enmity()
    {
        //控制动画朝向
        if (playerTransForm.position.x > transform.position.x)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else transform.localScale = new Vector3(1f, 1f, 1f);

        temp = playerTransForm.position;
        temp.y += 1.5f;
        if (Vector2.Distance(transform.position, temp) <= attackRange) {
            if (tempAttack <= 0) {
                Attack();
                tempAttack = attackCycle;
            }
            else {
                tempAttack -= Time.deltaTime;
            }
        }
        else {
            transform.position =
                Vector2.MoveTowards(transform.position, temp, speed * Time.deltaTime);
        }
    }

    new void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(StartAndEndAttack());
    }

    IEnumerator StartAndEndAttack()
    {
        yield return new WaitForSeconds(attackCd);
        collider2D.enabled = true;
        StartCoroutine(DisableAttack());
    }

    IEnumerator DisableAttack()
    {
        yield return new WaitForSeconds(attackTime);
        collider2D.enabled = false;
    }

    //玩家碰到怪物，受到伤害
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerCollider>().DamageByMonster(damage);
            Debug.Log("err");
        }
    }

    new void Death()
    {
        anim.SetTrigger("Die");
        StartCoroutine(DeathDetention());
    }

    IEnumerator DeathDetention()
    {
        yield return new WaitForSeconds(deathDetentionTime);
        Destroy(gameObject);
        gameObject.GetComponent<dropItems>().Drop();
    }

    //怪物受到伤害
    public override void TakeDamage(int takeDamage)
    {
        health -= takeDamage;
        GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
    }
}