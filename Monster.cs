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
    
    public void Update(){}

    public void Attack(){} //怪物攻击

    //�����ܵ��˺� �˺�ֵ��ʾ
    public GameObject floatPoint;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Patrol(){} //怪物巡逻

    public void Enmity(){} //怪物追踪玩家

    public void TakeDamage(int damage)
    {
        health -= damage;
        GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
    }
    
}
