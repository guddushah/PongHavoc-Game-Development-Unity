using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    Animator anim;
   // public GameObject GoTOBTN;
    //public GameObject BackNTn;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       
        }
    public void levelOne(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void GoToFacebookLink()
    {
        Application.OpenURL("https://www.facebook.com/srothcodegames/");
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene("LevelSclection");
    }
    public void GOHOme()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitLevel()
    {
        Application.Quit();
    }
    public void updateBTN()
    {
        //Application.OpenURL("https://play.google.com/store/apps/details?id=com.srothcodegames.PongHavoc");
        Application.OpenURL("market://details?id=com.srothcode.PongHavoc");
    }
    public void moreGames()
    {
        SceneManager.LoadScene("MoreGames");
    }
    public void GOTONEXT()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
    public void GOTONEXT2()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo2");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing2()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack2");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }

    public void GOTONEXT3()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo3");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing3()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack3");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }

    public void GOTONEXT4()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo4");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing4()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack4");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
    public void GOTONEXT5()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo5");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing5()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack5");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
    public void GOTONEXT6()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo6");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing6()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack6");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
    public void GOTONEXT7()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo7");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing7()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack7");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
    public void GOTONEXT8()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo8");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing8()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack8");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
    public void GOTONEXT9()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("GoTo9");
        //GoTOBTN.SetActive(false);
        //BackNTn.SetActive(true);
    }
    public void BackThing9()
    {
        //anim.SetTrigger("GoTo");
        GameObject.Find("LevelButtons").GetComponent<Animator>().SetTrigger("ComeBack9");
        //GoTOBTN.SetActive(true);
        //BackNTn.SetActive(false);
    }
}
