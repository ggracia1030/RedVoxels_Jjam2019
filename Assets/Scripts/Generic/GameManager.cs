using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public enum GameState { MainMenu, InGame, Pause, GameOver};
    GameState gameState;
    int currentLevel;
    public bool gamePaused;

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
        gameState = _gameState;
        currentLevel = level;
        if(gameState == GameState.InGame)
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

    public void ChangeToLevel(int level)
    {
        ChangeScene(gameState, level);
    }

    public void ChangeToNextLevel()
    {
        ChangeScene(gameState, ++currentLevel);
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
}
