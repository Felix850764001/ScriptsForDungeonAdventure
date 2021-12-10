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
        if (other.CompareTag("Item_SpeedUp")) {
            //捡到加速道具，获得10s加速效果
            UserInfo.Instance.Speed += 8;
            //更新玩家移动速度
            gameObject.GetComponent<PlayerMove>().Update_Speed();
            Destroy(other.gameObject);
            Invoke("Reset_Speed", 10);
        }
        else if (other.CompareTag("Item_HealthUp")) {
            //捡到回血道具 血量回1
            if (UserInfo.Instance.health != 5) {
                GameObject.Find("UserInfo").GetComponent<UserInfo>().recover_health();
            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Item_Shiled")) {
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

    //玩家收到伤害对于血量和护甲的减少反馈
    public void DamageByMonster()
    {
        //先判断是否处于无敌状态
        if (!UserInfo.Instance.isNB) {
            //后续根据怪物的攻击力调正减少值
            if (UserInfo.Instance.armor >= 2) {
                UserInfo.Instance.armor -= 2;
                UserInfo.Instance.healthOrarmor_update();
            }
            else if (UserInfo.Instance.armor == 1) {
                UserInfo.Instance.armor = 0;
                UserInfo.Instance.health -= 1;
                UserInfo.Instance.healthOrarmor_update();
            }
            else if (UserInfo.Instance.health >= 3) {
                UserInfo.Instance.health -= 2;
                UserInfo.Instance.healthOrarmor_update();
            }
            else //玩家血量归0后，无法移动，进入死亡状态，弹出game over 然后重新开始
            {
                UserInfo.Instance.health = 0;
                UserInfo.Instance.healthOrarmor_update();
            }
        }
    }
}