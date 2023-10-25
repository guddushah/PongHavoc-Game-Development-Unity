using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour {
    public GameObject Credit;
    public GameObject QuitGame;
    public bool onCredit = false;

    public bool quit = false;
    public GameObject btn;
  
    //public bool onGame = true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (onCredit == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    hideCredit();
                }
            }
            else if (onCredit==false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitGame.SetActive(true);
                    quit = true;
                }
            }

        }
    }
    public void ShowCredit()
    {
        onCredit = true;
        Credit.SetActive(true);
        btn.SetActive(false);
        //onMainMenu = false;
    }
    public void hideCredit()
    {
       
        Credit.SetActive(false);
        btn.SetActive(true);
        onCredit = false;
        //onMainMenu = true;

    }
    public void gotToLInk()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7019523049121428396");
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void DontQuit()
    {
        QuitGame.SetActive(false);
        
    }
}
