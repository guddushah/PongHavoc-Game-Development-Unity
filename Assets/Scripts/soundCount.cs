using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundCount : MonoBehaviour {

    public int counter;
    public Image soundIcon;
    public Sprite muteIcon,UnmuteIcon;
    

	// Use this for initialization
	void Start ()
    {
       // PlayerPrefs.SetInt("sound", 0);
        counter = PlayerPrefs.GetInt("sound");
        Debug.Log(PlayerPrefs.GetInt("sound"));
        
        if (counter == 0)
        {
            soundIcon.sprite = UnmuteIcon;
        }
        else if (counter == 1)
        {
            soundIcon.sprite = muteIcon;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void soundControl()
    {

/*
        if (counter == 1)
        {
            counter = 2;
            soundIcon.sprite = muteIcon;
        }
        else if (counter == 0)
        {
            counter = 1;
            soundIcon.sprite = UnmuteIcon;
        }
        else if (counter == 2) {
            counter = 1;
            soundIcon.sprite = UnmuteIcon;
        }
        */
        if (counter == 0)
        {
            counter = 1;
            soundIcon.sprite = muteIcon;
        }
        else if (counter == 1) {
            counter = 0;
            soundIcon.sprite = UnmuteIcon;
        }

        PlayerPrefs.SetInt("sound", counter);
        Debug.Log(PlayerPrefs.GetInt("sound"));
    }
   
}
