using UnityEngine;

public class StartStateControl : MonoBehaviour
{
    private Animator state;//获取启动页面玩家动画

    // Start is called before the first frame update
    private void Start()
    {
        state = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        state.SetInteger("AnimState", 1);
    }
}