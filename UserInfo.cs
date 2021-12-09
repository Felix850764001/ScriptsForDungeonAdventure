using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    //单例模式
    public static UserInfo Instance;

    //用户数据
    public float Speed;
    public float health;   //血量
    public float armor;    //护甲
    public int damage;  //攻击力

    //用户的血量条和护甲条
    public Slider slider_health;
    public Slider slider_armor;
    public Text text_health;
    public Text text_armor;

    //判断是否已经正在回复护甲
    private bool isRecoveringArmor = false;
    //判断是否处于无敌
    public bool isNB = false;

    void Start()
    {
        //玩家初始5点血 5点甲
        health = 3;
        armor = 0;

        slider_health.value = health/5;
        slider_armor.value = armor / 5;

        text_health.text = health + " \\ 5";
        text_armor.text = armor + " \\ 5";
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //护甲未满的状态下，每5s回复一点护甲
        if(armor != 5 && !isRecoveringArmor)
        {
            InvokeRepeating("recover_armor", 5, 5);
            isRecoveringArmor = true;
        }
        else if(armor == 5)
        {
            CancelInvoke("recover_armor");
            isRecoveringArmor = false;
        }
    }

    void recover_armor()
    {
        armor += 1;
        slider_armor.value = armor / 5;
        text_armor.text = armor + " \\ 5";
    }

    public void recover_health()
    {
        health += 1;
        slider_health.value = health / 5;
        text_health.text = health + " \\ 5";
    }

    //lynn新添加 更新血量和护甲值，用于玩家受到伤害。
    public void healthOrarmor_update()
    {
        slider_health.value = health / 5;
        slider_armor.value = armor / 5;

        text_health.text = health + " \\ 5";
        text_armor.text = armor + " \\ 5";
    }
}
