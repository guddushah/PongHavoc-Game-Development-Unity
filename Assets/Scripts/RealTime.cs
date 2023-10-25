using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RealTime : MonoBehaviour
{
    public static RealTime instance { get; set; }

    private ulong LastTimeValue;
    public float diplayingtime;

    public Text TimeText;
    public GameObject TimePanel;
    public int LockTheGame;

    public float HeartGenerationTime;
    public float Incresingtime;
    public float timeLeft;
    public int HeartAfterWaiting;

    float noOfHeartsToGenerate;
    float totalHeartAfter;
	ball BallScript;
    // Use this for initialization
    void Start ()
    {
        TimeText = GameObject.Find("Waiting Time Text").GetComponent<Text>();
        TimePanel = GameObject.Find("Timer");
		BallScript = GameObject.Find ("ball").GetComponent<ball> ();
       // PlayerPrefs.SetInt("remainingheart", 1);
        instance = this;
        //PlayerPrefs.SetString("WaitingTime", DateTime.Now.Ticks.ToString());
       
        LastTimeValue = ulong.Parse(PlayerPrefs.GetString("WaitingTime"));
        Debug.Log(LastTimeValue);
       // PlayerPrefs.SetInt("Gamelock", 0);
        //Debug.Log("Game is locked");
        //LockTheGame = PlayerPrefs.GetInt("Gamelock");
        if(PlayerPrefs.GetInt("Gamelock")==0)
        {
            Debug.Log("Game is not locked");
        }
        else
        {
            Debug.Log("Game is locked");
        }
        if(PlayerPrefs.GetInt("remainingball")==0)
        {
            Debug.Log("is it really working?");
        }
    }


    void Update ()
    {
        LastTimeValue = ulong.Parse(PlayerPrefs.GetString("WaitingTime"));
        ulong diff = (ulong)DateTime.Now.Ticks - LastTimeValue;

        ulong m = diff / TimeSpan.TicksPerMillisecond;

   
        float secondsleft = (m) / 1000;
        float timeLeft = 120-secondsleft;

        float timeLeftMinutesFloat = timeLeft / 60;

        float timeLeftSeconds = Mathf.Repeat(timeLeftMinutesFloat, 1.0f);

        timeLeftMinutesFloat -= timeLeftSeconds;

        timeLeftSeconds = Mathf.RoundToInt(timeLeftSeconds*60);

        float timeLeftMinutes = Mathf.RoundToInt(timeLeftMinutesFloat);

       // Debug.Log(timeLeftMinutes + "min : " + timeLeftSeconds + "sec");
        //Debug.Log(timeleftMinutesheart + "min : " + timeleftSecondsHeart + "sec");

        TimeText.text = "WAIT TIME : " +timeLeftMinutes.ToString() + " MIN " + timeLeftSeconds.ToString() + " SEC";
        noOfHeartsToGenerate = secondsleft / 120;
        noOfHeartsToGenerate -= Mathf.Repeat(noOfHeartsToGenerate, 1.0f);
        Debug.Log(noOfHeartsToGenerate);
		/*
        if (timeLeft <= 0)
        {
            PlayerPrefs.SetInt("Gamelock", 0);
            ball.ball_instance.timerPanel.gameObject.SetActive(false);
            Debug.Log("is it working?");
            ball.ball_instance.canInteract = true;
        }
        */
        if (PlayerPrefs.GetInt("remainingheart") < 10 && noOfHeartsToGenerate > 0)
        {
            totalHeartAfter = PlayerPrefs.GetInt("remainingheart") + noOfHeartsToGenerate;
            if (totalHeartAfter > 10)
            {
                totalHeartAfter = 10;
            }
            PlayerPrefs.SetInt("remainingheart", Mathf.RoundToInt(totalHeartAfter));
            PlayerPrefs.SetString("WaitingTime", DateTime.Now.Ticks.ToString());
			PlayerPrefs.SetInt("Gamelock", 0);
		//	ball.ball_instance.timerPanel.gameObject.SetActive(false);
		//	ball.ball_instance.canInteract = true;
			GameObject.Find("Timer").SetActive (false);
			BallScript.canInteract = true;
        }

    } 
}
