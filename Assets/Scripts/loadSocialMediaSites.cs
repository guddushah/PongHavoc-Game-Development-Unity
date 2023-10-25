using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadSocialMediaSites : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenFB()
    {
        Application.OpenURL("https://www.facebook.com/srothcodegames/");
    }
    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCwzkushH_Iu2fwX7yh4zlAg/videos");
    }
    public void OpenTwiter()
    {
        Application.OpenURL("https://twitter.com/Srothcode_Games");
    }
    
}
