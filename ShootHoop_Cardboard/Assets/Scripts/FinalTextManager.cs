﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTextManager : MonoBehaviour {

    public Text scoreText;

    // Use this for initialization
    void Start () {
        ScoreKeeper score = FindObjectOfType<ScoreKeeper>();
        scoreText.text = "Your Final Score is: " + score.score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
