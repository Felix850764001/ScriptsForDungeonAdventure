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

    public void Idle(){} //æªç©ç«ç«

    public void Walk(){} //æªç©ç§»å¨

    public void Attack(){} //æªç©æ»å»

    public void Death(){} //æªç©æ­»äº¡

    public void Patrol(){} //æªç©å·¡é»

    public void Enmity(){} //æªç©è¿½è¸ªç©å®¶
    public void TakeDamage(float takeDamage){} //æªç©æ¶å°æ»å»
}