using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemainingScript : MonoBehaviour {

    LevelManager lm;
    Text timeText;
    DataController data;
    

    // Use this for initialization
    void Start () {
        data = FindObjectOfType<DataController>();
        lm = FindObjectOfType<LevelManager>();
        timeText = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText(data.roundData.isTimeBased);       
    }

    void UpdateTimeText(bool countDown)
    {
        if (countDown)
        {
            timeText.text = "Time Remaining: " + Utilities.FormatTime(lm.timeToNextLevel);
        }
        else {
            timeText.text = "Time: " + Utilities.FormatTime(lm.timeToNextLevel);
            print("************************" + Utilities.FormatTime(lm.timeToNextLevel) + "*****************************");
        }
        
    }
}
