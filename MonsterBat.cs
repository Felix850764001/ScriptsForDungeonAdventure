using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBat : Monster
{
    public Transform[] movePosition;

    private int pos = 0;
    private float wait;
    private bool isEnmity;
    private Rigidbody2D m_rigidbody2D;
    private Animator anim;
    private Transform playerTransForm;
    private PolygonCollider2D collider2D;

    new void Start()
    {
        isEnmity = false;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        playerTransForm = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        wait = waitTime;
    }

    new void Update()
    {
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        if (!isEnmity) Patrol();
        else Attack();
    }

    new void Patrol()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, movePosition[pos].position, speed * Time.deltaTime);
        if (playerTransForm != null) {
            if (Vector2.Distance(transform.position, playerTransForm.position) <= warningRange) {
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

    new void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransForm.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, playerTransForm.position) < attackRange) {
            anim.SetTrigger("Attack");
            StartCoroutine(StartAndEndAttack());
        }
    }

    IEnumerator StartAndEndAttack()
    {
        yield return new WaitForSeconds(attackCd);
        collider2D.enabled = true;
        yield return new WaitForSeconds(attackTime);
        collider2D.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerCollider>().DamageByMonster();
        }
    }

    new void TakeDamage(float takeDamage)
    {
        health -= takeDamage;
    }
}
