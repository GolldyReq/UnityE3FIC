﻿using System.Collections;
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
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {
        float Hcamera = Input.GetAxis("R_Horizontal");

        transform.RotateAround(target.position, Vector3.up, Hcamera * m_Sensibility * Time.deltaTime);
        Vector3 norme = transform.position - target.transform.position;
        if (norme.y != 1.5f)
            norme.y = 1.5f;
        transform.position = norme.normalized * m_Distance + target.transform.position;
        transform.LookAt(target);
        //transform.position = new Vector3(transform.position.x, 1.5f + target.position.y, transform.position.z);
    }
}
