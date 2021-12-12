using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health;   //Ѫ��
    public int damage;   //������
    public bool monsterIsDie = false;

    private Animator anim;

    //�����ܵ��˺� �˺�ֵ��ʾ
    public GameObject floatPoint;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0&&!monsterIsDie)
        {
            anim.SetTrigger("Die");
            Destroy(gameObject,1);
            monsterIsDie = true;
            gameObject.GetComponent<dropItems>().Drop();
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
    }
    
}
