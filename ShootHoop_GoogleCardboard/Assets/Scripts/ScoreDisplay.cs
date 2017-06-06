using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    ScoreKeeper score;
    Text scoreText; 

	// Use this for initialization
	void Start () {
        score = FindObjectOfType<ScoreKeeper>();
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScoreText();        
	}

    void UpdateScoreText()
    {        
        //scoreText.text = "Score: " + score.score;
    }    

    public void UpdateFinalScoreText()
    {
        scoreText.text = "Your Final Score is: " + score;
    }
}
