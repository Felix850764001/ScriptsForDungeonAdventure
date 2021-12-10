using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health;   //ÑªÁ¿
    public int damage;   //¹¥»÷Á¦
    public bool monsterIsDie = false;

    private Animator anim;

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
    }
    
}
