using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public static HeartSystem HeartSystem_instance { get; set; }

    public int remainingball;
    public int remainingheart;
    public int scoregained;
    public int ballleftaftershooting;
    public int TotalCollectedScore;

    public Text displayremainingball;
    public Text displayremainingheart;
    public Text displayingthepoints;
    public Text TotalScore;

    bool PlayerHasPlayedBefore = false;
    public int CurrentScore;
    int PreviousScore;
    ball BallScript;
	// Use this for initialization
	void Start ()
    {
        BallScript = GameObject.Find("ball").GetComponent<ball>();
        Debug.Log("jjjj");
         Debug.Log("Current Level Score : " + PlayerPrefs.GetInt("Level" + BallScript.levelNum.ToString()));
        Debug.Log(BallScript.levelNum);
        HeartSystem_instance = this;    
    }
	
	// Update is called once per frame
	void Update ()
    {
        TextUpdate();      
    }

    public void TextUpdate()
    {
        ballleftaftershooting = PlayerPrefs.GetInt("presentball");
        scoregained = PlayerPrefs.GetInt("playerpoints");
        remainingball = PlayerPrefs.GetInt("remainingball");
        remainingheart = PlayerPrefs.GetInt("remainingheart");
        TotalCollectedScore = PlayerPrefs.GetInt("savecollectedcoins");

       // CurrentScore = PlayerPrefs.GetInt("Level" + ball.ball_instance.levelNum.ToString());
        //PreviousScore = PlayerPrefs.GetInt("previousscore");
        

       TotalScore.text = "SCORE: " + TotalCollectedScore.ToString();
        displayremainingball.text = "" + remainingball.ToString();
        displayremainingheart.text = "" + remainingheart.ToString();
        displayingthepoints.text = "SCORE: 10 X " + ballleftaftershooting.ToString() + " = " + scoregained.ToString();
        if (ball.ball_instance.totalball == 10)
        {
            PlayerPrefs.SetInt("playerpoints", 100);
            displayingthepoints.text ="SCORE:10 x 10 = 100";
        }
    }

    public void SaveScore()
    {
        if (CurrentScore >= PlayerPrefs.GetInt("Level" + ball.ball_instance.levelNum.ToString()))
        {
            PlayerPrefs.SetInt("Level" + ball.ball_instance.levelNum.ToString(), CurrentScore);
            //TotalScore.text = "SCORE: " + TotalCollectedScore.ToString();
        }
    }
}
