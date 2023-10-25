using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockSystem : MonoBehaviour {
    int maxLexel;
    string Levelname;
    public Sprite unlockSprite;
    public Sprite lockedSprite;
    public Sprite playingLevelSprite;
	// Use this for initialization
	void Start ()
    {
       
        GameObject.Find("Dipesh1").GetComponent<Button>().enabled = true;
        maxLexel = PlayerPrefs.GetInt("MaxLevelCompleted") ;
        //PlayerPrefs.SetInt("MaxLevelCompleted", 25);
        Debug.Log(maxLexel);
        for (int i = 0; i < maxLexel; i++)
        {
            //Debug.Log(Levelname);
            Levelname = "Dipesh" + (i+2).ToString();
            
            GameObject.Find(Levelname).GetComponent<Button>().enabled = true;
            GameObject.Find(Levelname).GetComponent<Image>().sprite = unlockSprite;
            GameObject.Find(Levelname).transform.GetChild(0).GetComponent<Text>().color = Color.black;
        }
        int currentLevelNum = maxLexel + 1;
        string currentLevelName = "Dipesh" + (currentLevelNum).ToString();
        GameObject.Find(currentLevelName).GetComponent<Image>().sprite = playingLevelSprite;
        GameObject.Find(currentLevelName).transform.GetChild(0).GetComponent<Text>().color = Color.white;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
