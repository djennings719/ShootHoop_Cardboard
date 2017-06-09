using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float timeToNextLevel = -1f;

    public GameObject introMenuPanel;
    public GameObject timeMenuPanel;
    public GameObject scoreMenuPanel;

    bool isTimeDefault;
    bool isGamePlaying;

    DataController data;
    ScoreKeeper score;

    // Use this for initialization
    void Start () {
        score = FindObjectOfType<ScoreKeeper>();
        data = FindObjectOfType<DataController>();
        timeToNextLevel = data.roundData.timeLimitInSeconds;
        checkIsTimeDefault();
	}
	
	// Update is called once per frame
	void Update () {
        
        //if (isGamePlaying) {
        //    print("-----------------round started");
            if (data.roundData.isTimeBased) {
                print("time based");
                timeToNextLevel -= Time.deltaTime;
                if (timeToNextLevel <= 0)
                {
                    data.roundData.isStarted = false;
                    isGamePlaying = false;
                    LoadNextScene();                    
                }
            }
            else {
                print("score based");
                timeToNextLevel += Time.deltaTime;
                if (score != null && score.score >= data.roundData.scoreLimit)
                {
                    data.roundData.isStarted = false;
                    isGamePlaying = false;
                    LoadNextScene();
                }
            }
        //}
        //else {
        //    print("-----------------round NOT started");
        //}

        //ScoreKeeper score = FindObjectOfType<ScoreKeeper>();
        //if (score != null && score.score >= 50) {
        //    LoadNextScene();
        //}
        //else if (Input.GetKeyDown(KeyCode.Space)) {
        //    LoadNextScene();
        //}
        //else if (Input.GetKeyDown(KeyCode.P)) {
        //    //LoadScene("01_Menu");
        //}
        //else if (Input.GetKeyDown(KeyCode.Q)) {
        //    QuitRequest();
        //}

        
        //print("Time to next level: " + timeToNextLevel);
        //if (!isTimeDefault) {
        //    print("Time entered and ready to check...");
        //    if (timeToNextLevel <= 0)
        //    {
        //        LoadNextScene();
        //    }
            
        //}
        //else {
        //    print("Default time value.  Do nothing yet!!");
        //}
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

    public void LoadMenuScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void LoadMenuSceneForTime() {
        introMenuPanel.SetActive(false);
        timeMenuPanel.SetActive(true);                
    }

    public void LoadMenuSceneForScore() {
        introMenuPanel.SetActive(false);
        scoreMenuPanel.SetActive(true);
    }

    public void StartGameForTime(int limit) {
        data.roundData.isTimeBased = true;
        data.roundData.timeLimitInSeconds = limit;
        timeMenuPanel.SetActive(false);
        introMenuPanel.SetActive(true);
        LoadGameScene();
    }

    public void StartGameForScore(int limit) {
        data.roundData.isTimeBased = false;
        data.roundData.scoreLimit = limit;
        scoreMenuPanel.SetActive(false);
        introMenuPanel.SetActive(true);
        LoadGameScene();
    }

    private void LoadGameScene() {
        isGamePlaying = true;
        SceneManager.LoadScene("02_Game");        
    }

    public void QuitRequest()
    {
        Application.Quit();
    } 
}
