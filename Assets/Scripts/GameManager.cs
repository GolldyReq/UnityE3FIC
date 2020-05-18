﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } }

    public enum GAMESTATE { Menu,Play,Pause,Victory,GameOver }
    GAMESTATE m_State;

    int m_Level;

    public bool IsPlaying {  get { return m_State == GAMESTATE.Play; } }

    public int m_Life;
    public int Life {  get { return m_Life; } }
    public int m_Score;
    public int Score { get { return m_Score; } }


    public event Action<GAMESTATE> OnGameStateChange;

    public event Action OnLevelSelect;
    public event Action<int> OnLoadingLevel;
    public event Action<int> OnDestroyLevel;

    public event Action<int> OnGameStatisticsChange;
    
    //public event Action OnNextLevel;
       
    //public event Action<int> OnScoreChange;
    //public event Action<int> OnLifeChange;

    void ChangeState(GAMESTATE state)
    {
        m_State = state;
        if (OnGameStateChange != null)
            OnGameStateChange(m_State);
    }

    void LoadingLevel(int level)
    {
        m_Level = level;
        if (OnLoadingLevel != null) OnLoadingLevel(m_Level);
    }

    void DestroyLevel()
    {
        if (OnDestroyLevel != null) OnDestroyLevel(m_Level);
    }


    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (MenuManager.Instance.IsReady == false)
            yield return null;

        while (LevelsManager.Instance.IsReady == false)
            yield return null;

        MenuManager.Instance.OnPlayButtonHasBeenClicked += PlayButtonHasBeenClicked;
        MenuManager.Instance.OnLevelFinish += LevelFinish;
        MenuManager.Instance.OnGameOver += GameOver;
        MenuManager.Instance.OnReplayButton += ReplayButton;
        MenuManager.Instance.OnNextLevelButton += NextLevelButton;
        MenuManager.Instance.OnExitButton += ExitButton;

        ChangeState(GAMESTATE.Menu);
        m_Level = 0;

    }


    void PlayButtonHasBeenClicked()
    {
        m_Life = 3;
        m_Score = 0;
        if (OnGameStatisticsChange != null) OnGameStatisticsChange(m_Life);
        ChangeState(GAMESTATE.Play);
        LoadingLevel(m_Level);
    }


    void LevelFinish()
    {
        ChangeState(GAMESTATE.Victory);
    }

    void GameOver()
    {
        ChangeState(GAMESTATE.GameOver);
    }

    void ReplayButton()
    {

    }

    void NextLevelButton()
    {

    }

    void ExitButton()
    {
        ChangeState(GAMESTATE.Menu);
        DestroyLevel();
    }

}
