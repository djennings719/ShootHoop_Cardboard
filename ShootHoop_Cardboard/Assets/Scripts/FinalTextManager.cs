using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTextManager : MonoBehaviour {

    public Text scoreText;

    DataController data;
    ScoreKeeper score;
    LevelManager lm;

    // Use this for initialization
    void Start () {
        score = FindObjectOfType<ScoreKeeper>();
        data = FindObjectOfType<DataController>();
        lm = FindObjectOfType<LevelManager>();
        updateText();
    }

    void updateText() {
        if (data.roundData.isTimeBased) {
            scoreText.text = "Your Final Score is: " + score.score;
        }
        else {
            scoreText.text = "Your Time is: " + Utilities.FormatTime(data.roundData.timeElapsed);
            print("*****************" + Utilities.FormatTime(data.roundData.timeElapsed) + "*****************");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
