using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float timeToNextLevel = -1f;

    //public float TimeToNextLevel {
    //    get { return timeToNextLevel; }
    //}

    bool isTimeDefault;

  	// Use this for initialization
	void Start () {
        checkIsTimeDefault();
	}
	
	// Update is called once per frame
	void Update () {

        ScoreKeeper score = FindObjectOfType<ScoreKeeper>();
        if (score != null && score.score >= 50) {
            LoadNextScene();
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            LoadNextScene();
        }
        else if (Input.GetKeyDown(KeyCode.P)) {
            //LoadScene("01_Menu");
        }
        else if (Input.GetKeyDown(KeyCode.Q)) {
            QuitRequest();
        }

        timeToNextLevel -= Time.deltaTime;
        print("Time to next level: " + timeToNextLevel);
        if (!isTimeDefault) {
            print("Time entered and ready to check...");
            if (timeToNextLevel <= 0)
            {
                LoadNextScene();
            }
            
        }
        else {
            print("Default time value.  Do nothing yet!!");
        }
	}

    void checkIsTimeDefault() {
        if (timeToNextLevel == -1) {
            isTimeDefault = true;
        }
        else {
            isTimeDefault = false;
        }
    }

    public void LoadNextScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentIndex + 1);   
        }
           
    }

    public void LoadPreviousScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex > 0)
        {
            SceneManager.LoadScene(currentIndex - 1);
            ScoreKeeper score = FindObjectOfType<ScoreKeeper>();
            score.score = 0;
        }
    }

    public void QuitRequest()
    {
        Application.Quit();
    } 
}
