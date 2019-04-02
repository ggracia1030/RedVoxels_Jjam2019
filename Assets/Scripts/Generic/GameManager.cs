using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    const int MAX_LEVEL = 5;
    public enum GameState { MainMenu, InGame, Pause, Credits};
    GameState gameState;
    int currentLevel;
    public bool gamePaused;

    bool changingScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        gameState = GameState.MainMenu;
        currentLevel = 0;
    }

    public void ChangeScene(GameState _gameState, int level = 0)
    {
        if (changingScene) return;
        gameState = _gameState;
        currentLevel = level;
        changingScene = true;
        StartCoroutine(FadeOutCamera(_gameState, level));
    }

    public void ChangeToLevel(int level)
    {
        ChangeScene(GameState.InGame, level);
    }

    public void ChangeToNextLevel()
    {
        if(++currentLevel >= MAX_LEVEL)
        {
            ChangeScene(GameState.Credits);
        }
        ChangeScene(GameState.InGame, currentLevel);
    }

    public void SetGamePaused(bool _paused)
    {
        if(_paused == gamePaused)
        {
            return;
        }
        gamePaused = _paused;
        if(gamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        GameObject.Find("PauseMenu").GetComponent<ActivatePauseMenu>().ActivePauseMenu(_paused);
    }

    IEnumerator FadeOutCamera(GameState _gameState, int level = 0)
    {
        float maxTime = 1;

        CanvasGroup mainCanvas = GameObject.Find("MainCanvas").GetComponent<CanvasGroup>();
        for(float time = 0; time < maxTime; time+=Time.deltaTime)
        {
            mainCanvas.alpha = time / maxTime;
            yield return null;
        }
        if (gameState == GameState.InGame)
        {
            changingScene = false;
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            changingScene = false;
            SceneManager.LoadScene(_gameState.ToString());
        }
        yield return null;
    }

    IEnumerator FadeInCamera()
    {
        float maxTime = 1;
        CanvasGroup mainCanvas = GameObject.Find("MainCanvas").GetComponent<CanvasGroup>();
        for (float time = maxTime; time > 0; time -= Time.deltaTime)
        {
            mainCanvas.alpha = time / maxTime;
            yield return null;
        }
        mainCanvas.alpha = 0;
    }
}
