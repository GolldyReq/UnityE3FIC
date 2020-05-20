using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMoveZ : MonoBehaviour
{

    [Range(-1,1)]
    [SerializeField] int m_Direction;

    [Range(0 , 10)]
    [SerializeField] int m_Speed;

    [Range(0, 10)]
    [SerializeField] float m_Distance;

    private Vector3 m_BasePosition;

    
    // Start is called before the first frame update
    void Start()
    {
        m_BasePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = Vector3.forward * m_Direction * m_Speed * Time.deltaTime;
        transform.Translate( move , Space.Self );
        if (transform.position.z > (m_BasePosition.z + m_Distance))
            m_Direction = -1;
        if (transform.position.z < (m_BasePosition.z - m_Distance))
            m_Direction = 1;

    }
    private void FixedUpdate()
    {
       
    }
}
