using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D coll2D;
    //玩家攻击的持续时间
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        //获取玩家动画
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //获取攻击范围碰撞体
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //玩家攻击
    public void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(startHitBox());
    }

    //等待0.1s后开始攻击检测 理解为攻击前摇
    IEnumerator startHitBox()
    {
        yield return new WaitForSeconds(0.1f);
        coll2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    //使用协程，判定玩家攻击完毕后，取消攻击检测
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }

    //玩家攻击
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<Monster>().TakeDamage(UserInfo.Instance.damage);
        }
    }
}
