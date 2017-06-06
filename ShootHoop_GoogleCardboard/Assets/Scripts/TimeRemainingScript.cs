using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemainingScript : MonoBehaviour {

    LevelManager lm;
    Text timeText;

    // Use this for initialization
    void Start () {
        lm = FindObjectOfType<LevelManager>();
        timeText = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText();
    }

    void UpdateTimeText()
    {        
        timeText.text = "Time Remaining: " + lm.timeToNextLevel;
    }

    //private void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //    UpdateTimeText();
    //}
}
