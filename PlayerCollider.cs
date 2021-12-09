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
    //    //如果碰到怪物 随机掉落道具
    //    if (other.gameObject.CompareTag("Monster"))
    //    {
    //        other.gameObject.GetComponent<dropItems>().Drop();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item_SpeedUp"))
        {
            //捡到加速道具，获得10s加速效果
            UserInfo.Instance.Speed += 8;
            //更新玩家移动速度
            gameObject.GetComponent<PlayerMove>().Update_Speed();
            Destroy(other.gameObject);
            Invoke("Reset_Speed", 10);
        } else if(other.CompareTag("Item_HealthUp"))
        {
            //捡到回血道具 血量回1
            if(UserInfo.Instance.health != 5)
            {
                GameObject.Find("UserInfo").GetComponent<UserInfo>().recover_health();
            }
            Destroy(other.gameObject);
        } else if(other.CompareTag("Item_Shiled"))
        {
            //捡到无敌道具 玩家无敌6s
            UserInfo.Instance.isNB = true;
            Invoke("Reset_NB", 6);
            Destroy(other.gameObject);
        }
    }

    //重置玩家速度
    public void Reset_Speed()
    {
        UserInfo.Instance.Speed = 8;
        gameObject.GetComponent<PlayerMove>().Update_Speed();
    }

    //重置玩家无敌状态
    public void Reset_NB()
    {
        UserInfo.Instance.isNB = false;
    }
}