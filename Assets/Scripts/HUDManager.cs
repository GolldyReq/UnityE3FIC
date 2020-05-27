using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public static HUDManager m_Instance;
    public static HUDManager Instance { get { return m_Instance; } }

    [SerializeField] Text m_NbLifeText;
    [SerializeField] Text m_NbScoreText;
    [SerializeField] Text m_TimerText;
    [SerializeField] Text m_SpeedPlayer;
    [SerializeField] Text m_HelpText;

    [SerializeField] Image m_PcButton;
    [SerializeField] Image m_XboxButton;
    [SerializeField] Image m_PsButton;

    private Player player;

    public int m_Score;
    public int m_Life;
    public int Score { get { return m_Score; } set { this.m_Score = Score; } }



    public void UpdateNbLife(int nLife)
    {
        m_Life = nLife;
        GameManager.Instance.m_Life = m_Life;
        m_NbLifeText.text = "Life : " + m_Life;
    }

    public void UpdateNbScore(int nScore)
    {
        m_Score += nScore;
        GameManager.Instance.m_Score = m_Score;
        m_NbScoreText.text = "Score : " + m_Score;
    }

    void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.OnGameStatisticsChange += UpdateNbLife;
        GameManager.Instance.OnGameStatisticsChange += UpdateNbScore;
        m_Score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PrintHelpText(string msg)
    {
        HUDManager.Instance.m_HelpText.text = msg;
    }
    public static void EraseHelpText()
    {
        HUDManager.Instance.m_HelpText.text = "";
    }

    public static void PrintButtonTouch(Image PcButton, Image XboxButton, Image PsButton)
    {
        HUDManager.Instance.m_PcButton.sprite = PcButton.sprite;
        HUDManager.Instance.m_XboxButton.sprite = XboxButton.sprite;
        HUDManager.Instance.m_PsButton.sprite = PsButton.sprite;
        HUDManager.Instance.m_PcButton.gameObject.SetActive(true);
        HUDManager.Instance.m_XboxButton.gameObject.SetActive(true);
        HUDManager.Instance.m_PsButton.gameObject.SetActive(true);
    }

    public static void EraseButtonTouch(Image PcButton, Image XboxButton, Image PsButton)
    {
        HUDManager.Instance.m_PcButton.gameObject.SetActive(false);
        HUDManager.Instance.m_XboxButton.gameObject.SetActive(false);
        HUDManager.Instance.m_PsButton.gameObject.SetActive(false);
    }
    public static void PrintSpeedPlayer(int speed)
    {
        HUDManager.Instance.m_SpeedPlayer.text = speed.ToString() + " km/h";
    }
    public static void PrintChrono(double time)
    {
        HUDManager.Instance.m_TimerText.text = time.ToString();
    }

}
