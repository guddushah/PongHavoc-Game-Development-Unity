using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {
    public GameObject btn;
    public GameObject Credit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowCredit()
    {
        Credit.SetActive(true);
        btn.SetActive(false);
    }
    public void hideCredit()
    {
        Credit.SetActive(false);
        btn.SetActive(true);
    }
    public void gotToLInk()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7019523049121428396");
    }

}
