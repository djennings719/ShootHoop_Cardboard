﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScoring : MonoBehaviour {

    public int scoreValue;
    ScoreKeeper score;
    

    // Use this for initialization
    void Start () {
        
        score = FindObjectOfType<ScoreKeeper>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        score.IncrementScore(scoreValue);        
    }
}
