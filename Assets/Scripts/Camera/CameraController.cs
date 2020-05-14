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

    void Start()
    {
        offsetCamera = transform.position - target.position;
    }

    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        float Hcamera = Input.GetAxis("R_Horizontal");

        transform.RotateAround(target.position, Vector3.up, Hcamera * m_Sensibility * Time.deltaTime);
        Vector3 norme = transform.position - target.transform.position;
        if (norme.y != 1.5f)
            norme.y = 1.5f;
        transform.position = norme.normalized * m_Distance + target.transform.position;
        //transform.LookAt(target);

        Vector3 targetPostition = new Vector3(target.position.x,
                                       this.transform.position.y,
                                       target.position.z);
        this.transform.LookAt(targetPostition);

        //transform.position = new Vector3(transform.position.x, 1.5f + target.position.y, transform.position.z);
    }
}
