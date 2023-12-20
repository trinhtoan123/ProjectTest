using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick_Screen1()
    {
        SceneManager.LoadScene("Test1");
    }
    public void Onclick_Screen2()
    {
        SceneManager.LoadScene("Test2");
    }
}
