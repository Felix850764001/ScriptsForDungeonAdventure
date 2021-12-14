using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public int health;//怪物生命值
    public int damage;//怪物伤害
    public int speed;//怪物移动速度
    public float waitTime;//怪物停滞时间
    public float warningRange;//怪物警戒范围
    public float attackRange;//怪物攻击范围
    public float attackCd;//怪物攻击前摇
    public float attackTime;//怪物攻击有效时间
    public float attackCycle;//怪物攻击周期
    public float deathDetentionTime;//怪物死亡后尸体滞留时间
    public GameObject floatPoint;
    public void Update(){}

    public void Attack(){} //怪物攻击
    
    public void Start() { }
    public void Patrol(){} //怪物巡逻

    public void Enmity(){} //怪物追踪玩家
    
    public void Death(){} //怪物死亡

    public abstract void TakeDamage(int damage);

}
