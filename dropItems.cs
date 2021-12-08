using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItems : MonoBehaviour
{
    //道具数组
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        //获取当前怪物的位置
        Vector3 pos = transform.position;
        pos.y += 1f;
        //获取随机掉落的道具对象并生成该道具
        Instantiate(items[Random.Range(0, items.Length)], pos, Quaternion.identity);
        //删除当前怪物对象
        Destroy(gameObject);
    }
}
