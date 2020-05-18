using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager m_Instance;
    public static LevelsManager Instance { get { return m_Instance; } }

    [SerializeField] GameObject[] m_Levels;
    GameObject m_CurrentLevel;

    public bool m_IsReady;
    public bool IsReady { get { return m_IsReady; } }

    void LoadLevel(int level)
    {
        // m_Levels = Instantiate(Level[Level]);
        level = Mathf.Max(level, 0) % m_Levels.Length;
        m_CurrentLevel = Instantiate(m_Levels[level]);
    }

    void DestroyLevel(int level)
    {
        Destroy(m_CurrentLevel);
    }

    void Awake()
    {
        m_IsReady = false;
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnLoadingLevel += LoadLevel;
        GameManager.Instance.OnDestroyLevel += DestroyLevel;
        m_IsReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
