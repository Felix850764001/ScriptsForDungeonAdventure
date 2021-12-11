using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    public float waitTime;
    public float warningRange;
    public float attackRange;
    public float attackCd;
    public float attackTime;
    
    public void Start(){}
    public void Update(){}

    public void Idle(){} //怪物站立

    public void Walk(){} //怪物移动

    public void Attack(){} //怪物攻击

    public void Death(){} //怪物死亡

    public void Patrol(){} //怪物巡逻

    public void Enmity(){} //怪物追踪玩家
    public void TakeDamage(float takeDamage){} //怪物收到攻击
}