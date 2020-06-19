using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;


    Vector3 offsetCamera;

    [SerializeField] float m_Distance;

    [Range(1, 200)]
    [SerializeField] float m_Sensibility;

    [Range(0, 5)]
    [SerializeField] float m_height;

    private static Vector3 m_InitialPosition;

    public void reset ()
    {
        transform.position = m_InitialPosition;
    }

    void Awake()
    {
        m_InitialPosition = target.position;
    }

    void Start()
    {
        offsetCamera = transform.position - target.position;
    }

    void Update()
    {
        //if (!GameManager.Instance.IsPlaying) return;

        if (Input.GetKey(KeyCode.Escape) || !GameManager.Instance.IsPlaying)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying) return;

        if (target == null)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            float Hcamera = Input.GetAxis("R_Horizontal");
            transform.RotateAround(target.position, Vector3.up, Hcamera * m_Sensibility * Time.deltaTime);
            Vector3 norme = transform.position - target.transform.position;
            if (norme.y != m_height)
                norme.y = m_height;
            transform.position = norme.normalized * m_Distance + target.transform.position;
            transform.LookAt(target);
            //transform.position = new Vector3(transform.position.x, 1.5f + target.position.y, transform.position.z);

            //Mouvement de haut en bas
            float moveCamVertical = Input.GetAxis("R_Vertical");
            m_height = m_height + 2 * (-moveCamVertical) * Time.fixedDeltaTime;
            //Empecher la camera d'être trop basse ou trop haute
            if (m_height < .5f)
                m_height = .5f;
            if (m_height > 2.5f)
                m_height = 2.5f;


        }
    }

    public void respawn()
    {
        gameObject.transform.position = m_InitialPosition;
    }

    public void setNewSpawnPos(Transform newPosition)
    {
        m_InitialPosition = newPosition.position;
    }
}
