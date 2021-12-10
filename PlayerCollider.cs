using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //lynn��� ��������������� 2021/12/10
    private void OnCollisionEnter2D(Collision2D other)
    {
        //�����������  ��ʱ�޵�1s
        if (other.gameObject.CompareTag("Monster"))
        {
            
            //other.gameObject.GetComponent<dropItems>().Drop();
            DamageByMonster(other.gameObject.GetComponent<Monster>().damage);
            UserInfo.Instance.isNB = true;
            Invoke("Reset_NB", 0.8f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item_SpeedUp"))
        {
            //�񵽼��ٵ��ߣ����10s����Ч�� //�޸�δ�̶�ֵUserInfo.Instance.Speed = 16�� ��Ȼ��һֱ������ȥ��2021/12/10
            UserInfo.Instance.Speed = 16; 
            //��������ƶ��ٶ�
            gameObject.GetComponent<PlayerMove>().Update_Speed();
            Destroy(other.gameObject);
            Invoke("Reset_Speed", 10);
        } else if(other.CompareTag("Item_HealthUp"))
        {
            //�񵽻�Ѫ���� Ѫ����1
            if(UserInfo.Instance.health != 5)
            {
                GameObject.Find("UserInfo").GetComponent<UserInfo>().recover_health();
            }
            Destroy(other.gameObject);
        } else if(other.CompareTag("Item_Shiled"))
        {
            //���޵е��� ����޵�6s
            UserInfo.Instance.isNB = true;
            Invoke("Reset_NB", 6);
            Destroy(other.gameObject);
        }
    }

    //��������ٶ�
    public void Reset_Speed()
    {
        UserInfo.Instance.Speed = 8;
        gameObject.GetComponent<PlayerMove>().Update_Speed();
    }

    //��������޵�״̬
    public void Reset_NB()
    {
        UserInfo.Instance.isNB = false;
    }

    //����յ��˺�����Ѫ���ͻ��׵ļ��ٷ���
    public void DamageByMonster(int damage)
    {
        //���ж��Ƿ����޵�״̬
        if (!UserInfo.Instance.isNB)
        {
            //m_animator.SetInteger("AnimState", 9);
            m_animator.SetTrigger("Hurt");
            
            //�������ݹ���Ĺ�������������ֵ
            if (UserInfo.Instance.armor >= damage)
            {
                UserInfo.Instance.armor -= damage;
                UserInfo.Instance.healthOrarmor_update();
            }
            else if (UserInfo.Instance.armor != 0)
            {
                int temp = (int)(damage - UserInfo.Instance.armor);
                UserInfo.Instance.armor = 0;
                if(UserInfo.Instance.health>temp)//���Ѫ����0���޷��ƶ�����������״̬������game over Ȼ�����¿�ʼ
                    UserInfo.Instance.health -= temp;
                else
                {
                    UserInfo.Instance.health = 0;
                    //��������״̬
                    //��ʼ
                    m_animator.SetTrigger("Death");
                }
                UserInfo.Instance.healthOrarmor_update();
            }
           
        }

    }
}