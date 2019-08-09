using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject btnObj = GameObject.Find("Canvas/BUtton");
        Button btn = (Button)btnObj.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onClick()
    {
        SceneManager.LoadScene("Main");
    }
}
