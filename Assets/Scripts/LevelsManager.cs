using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager m_Instance;
    public static LevelsManager Instance { get { return m_Instance; } }

    [SerializeField] GameObject[] m_Levels;
    GameObject m_CurrentLevel;
    [SerializeField] GameObject m_GO_Player;
    [SerializeField] GameObject m_GO_Camera;

    public bool m_IsReady;
    public bool IsReady { get { return m_IsReady; } }

    void LoadLevel(int level)
    {
        // m_Levels = Instantiate(Level[Level]);
        level = Mathf.Max(level, 0) % m_Levels.Length;
        m_CurrentLevel = Instantiate(m_Levels[level]);
        GameObject SpawnPlayer =GameObject.Find("PosSpawnPlayer");
        GameObject SpawnCamera =GameObject.Find("PosSpawnCamera");
        m_GO_Player.SetActive(true);
        m_GO_Player.GetComponent<Transform>().position= SpawnPlayer.transform.position;
        Debug.Log("Player pos : " + m_GO_Player.transform.position.ToString());

        m_GO_Camera.GetComponent<Transform>().position = SpawnCamera.transform.position;


        //Change le point de Respawn et charge les parametres du joueur
        m_GO_Player.GetComponent<Player>().setSpawnPosition(m_GO_Player.transform, m_GO_Camera.transform);
        m_GO_Player.GetComponent<Player>().LoadPlayer(); 

        Destroy(SpawnPlayer);
        Destroy(SpawnCamera);
        StartCoroutine(TimerCoroutine.TimerChrono(.0d));
    }

    void DestroyLevel(int level)
    {
        StopAllCoroutines();
        Destroy(m_CurrentLevel);
        m_GO_Player.SetActive(false);
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

}
