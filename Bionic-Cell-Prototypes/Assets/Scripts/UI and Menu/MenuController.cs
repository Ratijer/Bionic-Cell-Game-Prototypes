using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //For testing only
    public static MenuController instance;

    private void Awake()
    {
        //For testing only
        if(gameObject.name == "MenuControllerTest")
        {
            DontDestroyOnLoad(this);
            //This is so gameobject doesn't duplicate when going back and forth between scenes
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For testing only
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    //For prototypes only
    public void Prototype1()
    {
        SceneManager.LoadScene("Prototype1");
    }
    public void Prototype2()
    {
        SceneManager.LoadScene("Prototype2");
    }
    public void Prototype3()
    {
        SceneManager.LoadScene("Prototype3");
    }
    public void Prototype4()
    {
        SceneManager.LoadScene("Prototype4");
    }
    public void Prototype5()
    {
        SceneManager.LoadScene("Prototype5");
    }
    public void Prototype6()
    {
        SceneManager.LoadScene("Prototype6");
    }
    public void Prototype7()
    {
        SceneManager.LoadScene("Prototype7");
    }
    public void Prototype8()
    {
        SceneManager.LoadScene("Prototype8");
    }
    public void Prototype9()
    {
        SceneManager.LoadScene("Prototype9");
    }
}
