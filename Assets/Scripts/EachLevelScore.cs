using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EachLevelScore : MonoBehaviour {
    string Levelname;
    string Score;
	// Use this for initialization
	void Start () {
		GameObject.Find ("Dipesh1").transform.GetChild (1).GetComponent<Text> ().text = (PlayerPrefs.GetInt("Level1")).ToString() + "/100";
        for (int i = 1; i < 100; i++)
        {
           
            Levelname = "Dipesh" + (i).ToString();
            //Debug.Log(Levelname);
            Score = (PlayerPrefs.GetInt("Level" + i.ToString())).ToString() + "/100";
            Debug.Log(Levelname + ": " + Score);
			GameObject.Find (Levelname).transform.GetChild (1).GetComponent<Text> ().text = Score;
            //GameObject.Find(Levelname).GetComponent<Text>().text = Score;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
