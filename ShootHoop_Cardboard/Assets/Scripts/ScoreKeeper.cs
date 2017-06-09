using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    //public int score = 0;
    AudioSource audio;
    DataController data;
    public int score;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        data = FindObjectOfType<DataController>();
        audio = GetComponent<AudioSource>();
    }

    public void IncrementScore(int scoreValue)
    {
        score += scoreValue;
        audio.Play();
    }    
}
