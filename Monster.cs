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


    //怪物的自动移动
    void monster_move()
    {

    }
}
