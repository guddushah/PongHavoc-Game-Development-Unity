using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoreGamesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TapTapTurnLInk()
    {
        // Application.OpenURL("https://play.google.com/store/apps/details?id=com.Tapturn.srothcode");   
        //Application.OpenURL ("market://details?id=com.example.android");
        //"market://details?q=pname:com.myCompany.myAppName/"
        Application.OpenURL("market://details?id=com.Tapturn.srothcode");
    }
    public void HakuRun()
    {
        // Application.OpenURL("https://play.google.com/store/apps/details?id=com.ZYABA.haku");
        Application.OpenURL("market://details?id=com.ZYABA.haku");
    }
    public void DashainAayo()
    {
        // Application.OpenURL("https://play.google.com/store/apps/details?id=com.srothcode.DashainAayo");
        Application.OpenURL("market://details?id=com.srothcode.DashainAayo");
    }
    public void TileSwap()
    {
        //Application.OpenURL("https://play.google.com/store/apps/details?id=com.srothcode.tileswap");
        Application.OpenURL("market://details?id=com.srothcode.tileswap");
    }
    public void FireWorks()
    {
        //Application.OpenURL("https://play.google.com/store/apps/details?id=com.srothcodegames.fireworks");
        Application.OpenURL("market://details?id=com.srothcode.fireworks");
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu"); 
    }
}
