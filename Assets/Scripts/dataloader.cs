using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataloader : MonoBehaviour {
    public GameObject updateButton;
    public int noOfLevel;
    public Sprite commingSoonSprite;
    public Sprite updateSprite;
	// Use this for initialization
	IEnumerator Start () {
        //updateButton.SetActive(false);
        updateButton.GetComponent<Image>().sprite = commingSoonSprite;
        updateButton.GetComponent<Button>().enabled = false;
        WWW levelData = new WWW("http://srothcode.tech/ponghavoc/levelno.txt");
        yield return levelData;
        string levelDataString = levelData.text;
        int levelNum = int.Parse(levelDataString);
        if (levelNum > noOfLevel) {
            //updateButton.SetActive(true);
            updateButton.GetComponent<Image>().sprite = updateSprite;
            updateButton.GetComponent<Button>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
