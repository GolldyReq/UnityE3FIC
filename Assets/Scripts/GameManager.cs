using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } }

    public enum GAMESTATE { Menu,Play,Pause,Victory,GameOver,Credit }
    GAMESTATE m_State;

    int m_Level;

    public bool IsPlaying {  get { return m_State == GAMESTATE.Play; } }

    public int m_Life;
    public int Life { get { return m_Life; } set { m_Life = value; }  }
    public int m_Score;
    public int Score { get { return m_Score; } }


    public event Action<GAMESTATE> OnGameStateChange;

    public event Action OnLevelSelect;
    public event Action<int> OnLoadingLevel;
    public event Action<int> OnDestroyLevel;

    public event Action<int> OnGameStatisticsChange;
    
    //public event Action OnNextLevel;
       
    void ChangeState(GAMESTATE state)
    {
        m_State = state;
        if (OnGameStateChange != null)
            OnGameStateChange(m_State);
    }

   
    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }


    void Update()
    {
        if (Input.GetButton("Pause"))
            ChangeState(GAMESTATE.Pause);
        
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
        MenuManager.Instance.OnContinueButton += ContinueButton;
        MenuManager.Instance.OnCreditButton += CreditButton;
        MenuManager.Instance.OnMenuButton += MenuButton;

        ChangeState(GAMESTATE.Menu);
    }

    private void ResetStat()
    {
        m_Level = 0;
        m_Score = 0;
        m_Life = 5;
        HUDManager.Instance.ResetStat();
        HUDManager.Instance.UpdateNbScore(m_Score);
        HUDManager.Instance.UpdateNbLife(m_Life);
    }

    //Sauvegarde le score du joueur a chaque Checkpoint/Fin de partie/Game Over
    public static void SaveScore()
    {
        if(!PlayerPrefs.HasKey("BestScore"))
            PlayerPrefs.SetInt("BestScore", GameManager.Instance.m_Score);
        else
        {
            if (PlayerPrefs.GetInt("BestScore") < GameManager.Instance.m_Score)
                PlayerPrefs.SetInt("BestScore", GameManager.Instance.m_Score); 
        }
    }

    void PlayButtonHasBeenClicked()
    {
        ResetStat();
        if (OnGameStatisticsChange != null) { HUDManager.Instance.UpdateNbLife(m_Life); HUDManager.Instance.UpdateNbScore(m_Score); }
        ChangeState(GAMESTATE.Play);
        LoadingLevel(m_Level);
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

    void LevelFinish()
    {
        //Recompense le joueur s'il finit le niveau en moins de 15 min (+ il est rapide + il a de points)
        if (900 - HUDManager.Instance.m_TimeChrono > 0)
        {
            m_Score = m_Score + (900 - HUDManager.Instance.m_TimeChrono) * 100;
            HUDManager.Instance.UpdateNbScore(m_Score);
        }
        SaveScore();
        HUDManager.Instance.VictoryPrintFinalScore();
        ChangeState(GAMESTATE.Victory);
        AudioManager.StopAll();
        AudioManager.Play("Win");
        DestroyLevel();
    }

    void GameOver()
    {
        SaveScore();
        ChangeState(GAMESTATE.GameOver);
        //HUDManager.Instance.UpdateNbScore(m_Score);
        AudioManager.StopAll();
        AudioManager.Play("GameOver");
        HUDManager.Instance.GameOverPrintFinalScore();
        DestroyLevel();

    }

    void ReplayButton()
    {
        ResetStat();
        ChangeState(GAMESTATE.Play);
        LoadingLevel(m_Level);
    }

    void NextLevelButton()
    {
        ChangeState(GAMESTATE.Play);
        m_Level++;
        LoadingLevel(m_Level);
    }

    void ContinueButton()
    {
        ChangeState(GAMESTATE.Play);
    }

    void CreditButton()
    {
        ChangeState(GAMESTATE.Credit);
    }

    void MenuButton()
    {
        AudioManager.StopAll();
        DestroyLevel();
        ChangeState(GAMESTATE.Menu);
    }
}
