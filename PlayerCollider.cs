using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    //����������� ����������
    //    if (other.gameObject.CompareTag("Monster"))
    //    {
    //        other.gameObject.GetComponent<dropItems>().Drop();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item_SpeedUp"))
        {
            //�񵽼��ٵ��ߣ����10s����Ч��
            UserInfo.Instance.Speed += 8;
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
}