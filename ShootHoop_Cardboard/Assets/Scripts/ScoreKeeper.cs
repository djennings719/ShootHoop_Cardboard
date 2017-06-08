using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
    AudioSource audio;

    //public int Score
    //{
    //    get { return score; }
    //    set {
    //        score = value;
    //    }
    //}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void IncrementScore(int scoreValue)
    {
        score += scoreValue;
        audio.Play();
    }    
}
