using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } }

    public enum GAMESTATE { Menu,Play,Pause,Victory,GameOver }
    GAMESTATE m_State;

    public bool IsPlaying {  get { return m_State == GAMESTATE.Play; } }

    public event Action<GAMESTATE> OnGameStateChange;

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
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (MenuManager.Instance.IsReady == false)
            yield return null;


        MenuManager.Instance.OnPlayButtonHasBeenClicked += PlayButtonHasBeenClicked;
        MenuManager.Instance.OnLevelFinish += LevelFinish;
        MenuManager.Instance.OnGameOver += GameOver;

        ChangeState(GAMESTATE.Menu);
    }


    void PlayButtonHasBeenClicked()
    {
        ChangeState(GAMESTATE.Play);
    }

    void LevelFinish()
    {
        ChangeState(GAMESTATE.Victory);
    }

    void GameOver()
    {
        ChangeState(GAMESTATE.GameOver);
    }

}
