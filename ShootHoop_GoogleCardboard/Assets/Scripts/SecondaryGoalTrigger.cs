using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryGoalTrigger : MonoBehaviour {

    bool isColliderExpected;
    ScoreKeeper scoreKeeper;
    Collider expectedCollider;

    int score;

    void Start()
    {
        score = 0;
        isColliderExpected = false;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (expectedCollider == other) {
            scoreKeeper.IncrementScore(score);
            isColliderExpected = false;
        }
    }

    public void ExpectCollider(Collider collider, int scoreValue) {
        isColliderExpected = true;
        score = scoreValue;
        expectedCollider = collider;
    }
    
}
