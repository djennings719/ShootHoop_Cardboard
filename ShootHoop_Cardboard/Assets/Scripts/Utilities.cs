using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities {

    public static string FormatTime(float time) {
        string formattedTime;

        int seconds = Mathf.FloorToInt(time);

        if (time < 60.0)
        {
            formattedTime = "0:";// + time;
        }
        else {
            int minute = (int)time % 60;
            formattedTime = minute + ":";// + seconds;
        }

        if (seconds >=10) {
            formattedTime += seconds;
        }
        else {
            formattedTime += "0" + seconds;
        }

        //TODO - add milliseconds
                
        return formattedTime;
    }
	
}
