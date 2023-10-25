using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ball : MonoBehaviour
{
    public static ball ball_instance { get; set; }

	Vector2 startBallPos;
	Vector2 tempBallPos;
	Vector2 endBallPos;

	bool didClick;
	bool didDrag;
	public bool canInteract = true;

	float ballVelocityX;
	float ballVelocityY;
	Vector2 ballDirection;
	public float ballSpeed;
	Rigidbody2D rb2d;
	bool canCollide = false;
	int pitchNumber = 2;
    public bool Completed= false;
    Animator anim;
    public bool canCreate = false;
    public bool canPlay = false;

    public ParticleSystem ballParticle;

    public GameObject explosion;

    public GameObject lightObject;
    public int levelNum;
    GameObject LevelCompleteObj;
    GameObject TestObj;
    public AudioClip hitClip, victoryClip, boundaryClip;

     
    int Counter;
    public int adCounter;

    //Heart system
    public int presentheart;
    public int totalball = 10;
    public int presentball;
    public int totalheart = 10;

    //audio
    public int soundCounter;

    //level fail panel
     public GameObject levelfailpanel;

    bool canReload = true;
    public int ballpoints;
    public int TotalpointsCollected;

    int currentTime;
    int timeinterval;

    DateTime oldDate;
    DateTime currentDate;

    public GameObject timerPanel;
    public int LevelScore;
    public int CurrentScore;
    public int PreviousScore;

    bool HasPlayedBefore = false;
    

    void Start ()
    {
        //PlayerPrefs.SetInt("remainingheart", 1);
        LevelCompleteObj = GameObject.Find("TestImageCanvas");
        LevelCompleteObj.SetActive(false);
        levelfailpanel = GameObject.Find("LevelFailPanel");
        levelfailpanel.SetActive(false);
        if (PlayerPrefs.GetInt("Gamelock")== 1)
        {
            timerPanel.SetActive(true);
            canInteract = false;
        }
        
        //PlayerPrefs.SetInt("savecollectedcoins", 0);
       
        LevelScore = PlayerPrefs.GetInt("Level" + levelNum.ToString());
        Debug.Log("Level" + levelNum.ToString());

        totalball = PlayerPrefs.GetInt("remainingball");
        ballpoints = totalball * 10;
       
        //This is to set the ball and heart 10 in the first level
        if (PlayerPrefs.GetInt("FirstGame") == 0) {
            
            PlayerPrefs.SetInt("remainingball", 10);
            PlayerPrefs.SetInt("remainingheart", 10);
            PlayerPrefs.SetInt("FirstGame", 1);
        }
        
        ball_instance = this;
        totalball = PlayerPrefs.GetInt("remainingball");
        totalheart = PlayerPrefs.GetInt("remainingheart");
        soundCounter = PlayerPrefs.GetInt("sound");

        adCounter = PlayerPrefs.GetInt("counter");

        rb2d = GetComponent<Rigidbody2D> ();
        //	rb2d.velocity = new Vector2 (3, 0);
        //levelfailpanel.SetActive(false);
        ParticleSystem.EmissionModule BallparticleEmmision = ballParticle.emission;
        BallparticleEmmision.enabled = false;
        lightObject = GameObject.Find("2DPointLightWithGradient");
        lightObject.SetActive(false);
        timerPanel = GameObject.Find("Timer");
        timerPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(ballpoints);
        // soundCounter = PlayerPrefs.GetInt("sound");   

        if (Input.GetMouseButtonDown (0) && canInteract)
        {
			mouseClicked ();
		}
		if (Input.GetMouseButtonUp (0) && canInteract && canCreate)
        {
			mouseReleased ();
            //canInteract = false;
            canCreate = false;
		}
		if (Input.GetKeyDown (KeyCode.R))
        {
			//SceneManager.LoadScene ("Level3");
		}
		Vector3 tempPosNow = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		tempPosNow.z = 0;
		GameObject.Find ("LineRenderer").GetComponent<LineRenderer> ().SetPosition (0, transform.position);
		GameObject.Find ("LineRenderer").GetComponent<LineRenderer> ().SetPosition (1, tempPosNow);

    }

	void mouseClicked()
    {
		//startBallPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mouseClickedPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mouseClickedPos;
		//transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<CircleCollider2D> ().enabled = true;
		//GameObject.Find ("LineRenderer").GetComponent<LineRenderer> ().enabled = true;
	}

	void mouseReleased()
    {
		GameObject.Find ("LineRenderer").GetComponent<LineRenderer> ().enabled = false;
		startBallPos = transform.position;
		canCollide = true;
		endBallPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ballVelocityX = startBallPos.x - endBallPos.x;
		ballVelocityY = startBallPos.y - endBallPos.y;
		ballDirection = new Vector2 (ballVelocityX, ballVelocityY).normalized;
        //rb2d.velocity = -ballDirection * ballSpeed;

        if (Mathf.Abs(ballVelocityX) > 0.1 || Mathf.Abs(ballVelocityY) > 0.1)
        {
            //		ballDirection = new Vector2 (ballVelocityX, ballVelocityY).normalized;


            rb2d.velocity = -ballDirection * ballSpeed;
            canInteract = false;
            GameObject.Find("LineRenderer").GetComponent<LineRenderer>().enabled = false;
        }
        else
        {
            GetComponent<CircleCollider2D>().enabled = false;

            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("LineRenderer").GetComponent<LineRenderer>().enabled = false;
            canInteract = true;
            canPlay = false;
        }
	}

	void OnCollisionEnter2D(Collision2D col)
    {
		if (!canCollide)
        {
			return;
		}
        if (canPlay)
        {
            if (col.gameObject.GetComponent<PolygonCollider2D>())
            {
                if (soundCounter == 0)
                {
                    col.gameObject.GetComponent<AudioSource>().volume = 1f;
                }
                else if (soundCounter == 1)
                {
                    col.gameObject.GetComponent<AudioSource>().volume = 0f;
                }
                

                col.gameObject.GetComponent<Animator>().SetTrigger("hit");
                col.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                float pitch = Mathf.Pow(2f, pitchNumber / 12.0f);
                pitchNumber++;
                col.gameObject.GetComponent<AudioSource>().pitch = pitch;
               // col.gameObject.GetComponent<AudioSource>().volume = 0.8f;
                col.gameObject.GetComponent<AudioSource>().clip = hitClip;
                col.gameObject.GetComponent<AudioSource>().Play();
               
            }

            if (col.gameObject.GetComponent<BoxCollider2D>())
            {
                if (soundCounter == 0)
                {
                    col.gameObject.GetComponent<AudioSource>().volume = 1f;
                }
                else if (soundCounter == 1)
                {
                    col.gameObject.GetComponent<AudioSource>().volume = 0f;
                }

                col.gameObject.GetComponent<Animator>().SetTrigger("hit");
                col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                float pitch = Mathf.Pow(2f, pitchNumber / 12.0f);
                pitchNumber++;
                col.gameObject.GetComponent<AudioSource>().pitch = pitch;
                col.gameObject.GetComponent<AudioSource>().clip = hitClip;
                col.gameObject.GetComponent<AudioSource>().Play();                
            }

            if (col.gameObject.GetComponent<CircleCollider2D>())
            {
                if (soundCounter == 0)
                {
                    col.gameObject.GetComponent<AudioSource>().volume = 1f;
                }
                else if (soundCounter == 1)
                {
                    col.gameObject.GetComponent<AudioSource>().volume = 0f;
                }

                col.gameObject.GetComponent<Animator>().SetTrigger("hit");
                col.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                float pitch = Mathf.Pow(2f, pitchNumber / 12.0f);
                pitchNumber++;
                col.gameObject.GetComponent<AudioSource>().pitch = pitch;
                col.gameObject.GetComponent<AudioSource>().clip = hitClip;
                col.gameObject.GetComponent<AudioSource>().Play();
            }
        }       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "gate"&& canPlay  )
        {
            // Debug.Log("go to level 2");
            if (soundCounter == 0)
            {
                GetComponent<AudioSource>().volume = 1f;
            }
            else if (soundCounter == 1)
            {
                GetComponent<AudioSource>().volume = 0f;
            }
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            canPlay = false;
            
            //GameObject.Find("Game CompletedAnim").GetComponent<Animator>().SetTrigger("Comp");
            //       LevelCompleteObj.SetActive(true);
            //     LevelCompleteObj.GetComponent<Animator>().SetTrigger("win");
            GameObject.Find("goal").GetComponent<Animator>().SetTrigger("goal");
           
            Completed = true;
           
            StartCoroutine("waitWin");
            StartCoroutine("playVictorySound");
            if (levelNum > PlayerPrefs.GetInt("MaxLevelCompleted"))
            {
                PlayerPrefs.SetInt("MaxLevelCompleted", levelNum);
            }
            GameObject.Find("BackButton").SetActive(false);
            GameObject.Find("Level Text").SetActive(false);
            //this.gameObject.SetActive(false);
            if (levelNum == 3 || levelNum == 5 || levelNum == 7 || levelNum == 9 || levelNum == 11)
            {

               //advertisementManager.instance.showVideo();
            }
            else if (levelNum > 11)
            {
                //advertisementManager.instance.showVideo();
            }
            PlayerPrefs.SetInt("remainingball", 10);
            TotalpointsCollected = PlayerPrefs.GetInt("savecollectedcoins")+ballpoints;
            PlayerPrefs.SetInt("savecollectedcoins", TotalpointsCollected);
            HeartSystem.HeartSystem_instance.CurrentScore = ballpoints;
            HeartSystem.HeartSystem_instance.SaveScore();
           
        }
        if (other.tag == "home" && canInteract)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("LineRenderer").GetComponent<LineRenderer>().enabled = true;
            canPlay = true;
            canCreate = true;

            ParticleSystem.EmissionModule BallparticleEmmision = ballParticle.emission;
            BallparticleEmmision.enabled = true;

            lightObject.SetActive(true);              
        }
        else
        {
            ParticleSystem.EmissionModule BallparticleEmmision = ballParticle.emission;
            BallparticleEmmision.enabled = false;
        }

        if (other.gameObject.tag == "boundary" && canPlay)
        {
            if (soundCounter == 0)
            {
                GetComponent<AudioSource>().volume = 1f;
            }
            else if (soundCounter == 1)
            {
                GetComponent<AudioSource>().volume = 0f;
            }
            
            totalball = totalball - 1;
            PlayerPrefs.SetInt("remainingball", totalball);
            PlayerPrefs.SetInt("presentball", totalball);
            Debug.Log("The ball is reduced");
            
            
            ballpoints = totalball * 10;
            
            PlayerPrefs.SetInt("previousscore", ballpoints);
            PlayerPrefs.SetInt("currentscore", ballpoints);
            //PlayerPrefs.SetInt("savecollectedcoins", ballpoints);
            PlayerPrefs.SetInt("playerpoints", ballpoints);
            
            if(totalball==0||totalball<0)
            {               
                //RealTime.instance.TimePanel.gameObject.SetActive(true);                
                levelfailpanel.gameObject.SetActive(true);
                canReload = false;                   
                totalball = 10;    
                totalheart = totalheart - 1;
                ballpoints = totalball * 10;
                
               // PlayerPrefs.SetInt("savecollectedcoins", ballpoints);
                PlayerPrefs.SetInt("playerpoints", ballpoints);
                PlayerPrefs.SetInt("remainingball", totalball);
                PlayerPrefs.SetInt("remainingheart", totalheart);
                PlayerPrefs.SetInt("presentball", totalball);

                if (totalheart==0||totalheart<0)
                {
                    PlayerPrefs.SetString("WaitingTime", DateTime.Now.Ticks.ToString());
                    timerPanel.SetActive(true);
                    PlayerPrefs.SetInt("Gamelock", 1);
                    //totalheart = 1;
                   // PlayerPrefs.SetInt("remainingheart", totalheart);
                }
                if(totalheart<10)
                {
                    //timerPanel.SetActive(true);
                }
            }

           // PlayerPrefs.SetInt("remainingball",totalball);
            //PlayerPrefs.SetInt("remainingheart", totalheart);
            Debug.Log(PlayerPrefs.GetInt("remainingball"));

            // GameObject.Find("ErrorSound").GetComponent<AudioSource>().Play();
            // Handheld.Vibrate();
            Camera.main.GetComponent<Animator>().SetTrigger("shake");
            Instantiate(explosion, transform.position, transform.rotation);
            GetComponent<AudioSource>().clip = boundaryClip;
            GetComponent<AudioSource>().Play();
            if (canReload)
            {
                StartCoroutine("waitforReload");
            }
            
            GetComponent<SpriteRenderer>().enabled = false;
            
            adCounter++;
            PlayerPrefs.SetInt("counter", adCounter);

            if (adCounter >= 10 )
            {
                //advertisementManager.instance.showVideo();
                adCounter = 0;
                PlayerPrefs.SetInt("counter", adCounter);
            }
            if (totalheart == 9)
            {
                PlayerPrefs.SetString("WaitingTime", DateTime.Now.Ticks.ToString());
                PlayerPrefs.GetInt("remainingheart", 9);
            }
        }
    }

	public void ReloadLevel()
    {
		//SceneManager.LoadScene
	}

    void OnBecameInvisible()
    {
        rb2d.velocity = Vector2.zero;
        canInteract = true;
        canPlay = false;
        GetComponent<SpriteRenderer>().enabled = false;
        if (!Completed)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //or 
            
           // Instantiate(explosion, transform.position, transform.rotation);
        }

       

        //SceneManager.LoadScene("level7");
        //SceneManager.LoadScene("level8");
        //SceneManager.LoadScene("level6");
        //SceneManager.LoadScene("level3");
    }

    IEnumerator waitforReload()
    {
        yield return new WaitForSeconds(0.7f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    IEnumerator waitWin() {
        yield return new WaitForSeconds(0.35f);
        LevelCompleteObj.SetActive(true);
        LevelCompleteObj.GetComponent<Animator>().SetTrigger("win");    
    }
    IEnumerator playVictorySound() {
        yield return new WaitForSeconds(0.7f);
        playVictory();
    } 

    public void playVictory() {
        

        if (soundCounter == 0)
        {
            GetComponent<AudioSource>().volume = 1f;
        }
        else if (soundCounter == 1)
        {
            GetComponent<AudioSource>().volume = 0f;
        }

        GetComponent<AudioSource>().clip = victoryClip;

        GetComponent<AudioSource>().Play();
    }

    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
