using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginController : MonoBehaviour
{
    public Button beginButton;
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        beginButton.onClick.AddListener(BeginGame);
        closeButton.onClick.AddListener(CloseGame);

        Application.targetFrameRate = 60;
    }
    void BeginGame()
    {
        SceneManager.LoadScene("Main");
    }
    void CloseGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
