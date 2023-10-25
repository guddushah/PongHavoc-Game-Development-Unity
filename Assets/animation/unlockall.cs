using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UnlockAllLevel() {
        PlayerPrefs.SetInt("MaxLevelCompleted", 200);
        Application.LoadLevel(Application.loadedLevel);
    }
}
