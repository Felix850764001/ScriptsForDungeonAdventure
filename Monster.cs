using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator monster_worm;
    // Start is called before the first frame update
    void Start()
    {
        monster_worm.Play("walk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //������Զ��ƶ�
    void monster_move()
    {

    }
}
