using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        Debug.Log("我是打印日志");
        Debug.LogError("我是打印错误日志");

        GUI.skin.label.fontSize = 80;

        GUI.Label(new Rect(100, 100, Screen.width, Screen.height), "Hello World");
    }
}
