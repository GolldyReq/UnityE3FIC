using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public static HUDManager m_Instance;
    public static HUDManager Instance { get { return m_Instance; } }

    [SerializeField] Text m_NbLifeText;
    [SerializeField] Text m_NbScoreText;

    private PlayerController player;


    public void UpdateNbLife(int nLife)
    {
        m_NbLifeText.text = "Life : " + nLife ;
    }

    void UpdateNbScore(int nScore)
    {
        m_NbScoreText.text = "Score : " + nScore;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
