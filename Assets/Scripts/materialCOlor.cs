using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialCOlor : MonoBehaviour {

    public float fadePerSec;
    public Material lightMat;
    Color matColor;

	// Use this for initialization
	void Start () 
    {
       
	}
	
	// Update is called once per frame
	void Update () 
    {
        lightMat = GetComponent<Renderer>().material;
        lightMat.color = matColor;

        lightMat.color = new Color(matColor.r, matColor.b, matColor.g, matColor.a - (fadePerSec * Time.deltaTime));
	}
}
