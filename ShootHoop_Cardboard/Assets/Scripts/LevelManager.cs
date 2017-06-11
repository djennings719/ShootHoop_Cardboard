using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float timeToNextLevel = -1f;

    public GameObject introMenuPanel; //Top Menu Panel
    public GameObject timeMenuPanel;  //Menu Panel for timed games
    public GameObject scoreMenuPanel; //Menu Panel for scored games

    public GameObject timeCounterPanel;

    bool isGamePlaying;

    DataController data;
    ScoreKeeper score;

    // Use this for initialization
    void Start () {
        isGamePlaying = false;
        score = FindObjectOfType<ScoreKeeper>();
        data = FindObjectOfType<DataController>();
        timeToNextLevel = data.roundData.timeLimitInSeconds;
	}
	
	// Update is called once per frame
	void Update () {
        if (data != null)
        {
            if (data.roundData.isTimeBased)
            {
                timeToNextLevel -= Time.deltaTime;
                if (timeToNextLevel <= 0)
                {
                    data.roundData.isStarted = false;
                    isGamePlaying = false;
                    LoadNextScene();
                }
            }
            else
            {
                timeToNextLevel += Time.deltaTime;
                if (score != null && score.score >= data.roundData.scoreLimit)
                {
                    data.roundData.isStarted = false;
                    data.roundData.timeElapsed = timeToNextLevel;
                    isGamePlaying = false;
                    LoadNextScene();
                }
            }
        }
        else
        {
            print("******************Please make sure you are starting from Scene 00_Persistent*******************");
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

    public void LoadMainMenu() {
        SceneManager.LoadScene("01_Menu");
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
        print("************START GAME FOR TIME*******************");
        data.roundData.isTimeBased = true;
        data.roundData.timeLimitInSeconds = limit;
        LoadGameScene();
        timeMenuPanel.SetActive(false);
        introMenuPanel.SetActive(true);
        print("************END START GAME FOR TIME*******************");
    }

    public void StartGameForScore(int limit) {
        print("************START GAME FOR SCORE*******************");
        data.roundData.isTimeBased = false;
        data.roundData.scoreLimit = limit;
        timeToNextLevel = 0;
        LoadGameScene();
        scoreMenuPanel.SetActive(false);
        introMenuPanel.SetActive(true);
        print("************END START GAME FOR TIME*******************");
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
