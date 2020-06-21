using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{

    public static MenuManager m_Instance;
    public static MenuManager Instance { get { return m_Instance; } }

    bool m_IsReady;
    public bool IsReady { get { return m_IsReady; } }

    [SerializeField] GameObject m_MenuPanel;
    [SerializeField] GameObject m_VictoryPanel;
    [SerializeField] GameObject m_GameOverPanel;
    [SerializeField] GameObject m_PlayPanel;
    [SerializeField] GameObject m_PausePanel;
    [SerializeField] GameObject m_CreditPanel;

    List<GameObject> m_Panels = new List<GameObject>();

    EventSystem eventSystem;


    public event Action OnPlayButtonHasBeenClicked;

    public event Action OnReplayButton;
    public event Action OnNextLevelButton;
    public event Action OnMenuButton;
    public event Action OnContinueButton;
    public event Action OnLevelFinish;
    public event Action OnGameOver;
    public event Action OnCreditButton;

    private void ActivatePannel(GameObject pannel)
    {
        foreach (var item in m_Panels)
            item.SetActive(item == pannel);
    }

    void GameStateChange(GameManager.GAMESTATE state)
    {
        switch(state)
        {
            case GameManager.GAMESTATE.Menu:
                ActivatePannel(m_MenuPanel);
                eventSystem.SetSelectedGameObject(GameObject.Find("PlayButton"));
                break;
            case GameManager.GAMESTATE.Play:
                ActivatePannel(m_PlayPanel);
                break;
            case GameManager.GAMESTATE.Victory:
                ActivatePannel(m_VictoryPanel);
                eventSystem.SetSelectedGameObject(GameObject.Find("NextLevel"));
                break;
            case GameManager.GAMESTATE.GameOver:
                ActivatePannel(m_GameOverPanel);
                eventSystem.SetSelectedGameObject(GameObject.Find("ExitButton"));
                break;
            case GameManager.GAMESTATE.Pause:
                ActivatePannel(m_PausePanel);
                eventSystem.SetSelectedGameObject(GameObject.Find("ContinueButton"));
                break;
            case GameManager.GAMESTATE.Credit:
                ActivatePannel(m_CreditPanel);
                eventSystem.SetSelectedGameObject(GameObject.Find("ToMenuButton"));
                break;
        }
    }

    private void Awake()
    {

        m_IsReady = false;
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
        
        m_Panels.Add(m_MenuPanel);
        m_Panels.Add(m_VictoryPanel);
        m_Panels.Add(m_GameOverPanel);
        m_Panels.Add(m_PlayPanel);
        m_Panels.Add(m_PausePanel);
        m_Panels.Add(m_CreditPanel);

        eventSystem = GameObject.FindObjectOfType<EventSystem>();
        
    
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateChange += GameStateChange;
        m_IsReady = true;
    }

    public void PlayButtonHasBeenClicked()
    {
        if (OnPlayButtonHasBeenClicked != null) OnPlayButtonHasBeenClicked();
    }

    public void LevelFinish()
    {
        if (OnLevelFinish != null) OnLevelFinish();
    }

    public void GameOver()
    {
        if (OnGameOver != null) OnGameOver();
    }

    public void ReplayButton()
    {
        if (OnReplayButton != null) OnReplayButton();
    }

    public void NextLevelButton()
    {
        if (OnNextLevelButton != null) OnNextLevelButton();
    }

    public void ContinueButton()
    {
        if (OnContinueButton != null) OnContinueButton();
    }
    
    public void CreditButton()
    {
        if (OnCreditButton != null) OnCreditButton();
    }

    public void MenuButton()
    {
        if (OnMenuButton != null) OnMenuButton();
    }
}
