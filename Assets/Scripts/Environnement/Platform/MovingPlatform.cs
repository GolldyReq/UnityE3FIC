using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    [Range(-1,1)]
    [SerializeField]public int m_Direction;

    [Range(0 , 10)]
    [SerializeField]public float m_Speed;
    [Range(0 , 10)]
    [SerializeField]public float m_Time;



    [Range(0, 10)]
    [SerializeField] float m_X;
    [Range(0, 10)]
    [SerializeField] float m_Y;
    [Range(0, 10)]
    [SerializeField] float m_Z;
    
    //private Vector3 m_BasePosition;
    //Valeur max dans le sens positif et negatif
    public Vector3 m_GoalPos;
    public Vector3 m_GoalNeg;

    public bool coroutinePlaying;

    // Start is called before the first frame update
    void Start()
    {
        m_GoalPos = new Vector3(transform.position.x + m_X , transform.position.y + m_Y , transform.position.z + m_Z);
        m_GoalNeg = new Vector3(transform.position.x - m_X , transform.position.y - m_Y , transform.position.z - m_Z);
        coroutinePlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!coroutinePlaying)
            StartCoroutine(PlatformTool.MovePlatform(this, m_Time));
    }
}
