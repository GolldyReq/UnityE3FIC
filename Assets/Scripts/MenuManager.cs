using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager m_Instance;
    public static MenuManager Instance { get { return m_Instance; } }

    bool m_IsReady;
    public bool IsReady { get { return m_IsReady; } }

    [SerializeField] GameObject m_MenuPanel;

    List<GameObject> m_Panels = new List<GameObject>();


    public event Action OnPlayButtonHasBeenClicked;

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
                break;
            case GameManager.GAMESTATE.Play:
                ActivatePannel(null);
                break;
            case GameManager.GAMESTATE.Vicrory:
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

        Debug.Log("oui");

        Debug.Log(m_MenuPanel.name);
        
        if(m_MenuPanel != null)
            m_Panels.Add(m_MenuPanel);
        
    
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
}
