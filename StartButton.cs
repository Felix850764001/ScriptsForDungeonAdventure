using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Text start;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        //color = start.color;
        //color.a = 0f;
        //start.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.Lerp
    }

    public void GetStart()
    {
        SceneManager.LoadScene("Start");
    }
}
