using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {
	int scoreTotal;
	int scoreTemp;
	Text totalScoreText;
	int maxLevel;
	string canvasText;
	// Use this for initialization
	void Start () {
		maxLevel = PlayerPrefs.GetInt("MaxLevelCompleted") ;
		if (GameObject.Find ("GameCanvas"))
        {
			canvasText = "GameCanvas/Score Text";
		}else if(GameObject.Find("GameCanvas (1)/Score Text"))
        {
			canvasText = "GameCanvas (1)/Score Text";
		}
		//totalScoreText = GameObject.Find ("GameCanvas (1)/Score Text").GetComponent<Text> ();
		totalScoreText = GameObject.Find (canvasText).GetComponent<Text> ();
		for (int i = 1; i < (maxLevel+1); i++) {
			scoreTemp = PlayerPrefs.GetInt ("Level" + i.ToString ());

			scoreTotal += scoreTemp;
			Debug.Log ("ScoreTemp"+i.ToString()+": "+scoreTemp);
		}
		totalScoreText.text = "SCORE: "+ scoreTotal.ToString ();		
	}
	
}
