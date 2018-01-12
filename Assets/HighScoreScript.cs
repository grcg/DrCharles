using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // TODO: sets the text in end scene
        GetComponent<Text>().text = "GAME OVER!\nHIGH SCORE: " + PlayerPrefs.GetInt("highScore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
