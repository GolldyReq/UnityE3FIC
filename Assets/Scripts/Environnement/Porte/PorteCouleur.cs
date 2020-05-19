﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteCouleur : MonoBehaviour
{

    BoxCollider bc_door;
    Material m_door;
    private string[] m_name;

    void Awake()
    {
        
        bc_door = gameObject.GetComponentInChildren<BoxCollider>();
        m_door = gameObject.GetComponentInChildren<MeshRenderer>().material;
        m_name = m_door.name.Split(' ');
    }
    // Start is called before the first frame update
    void Start()
    {
        bc_door.enabled = true;
        bc_door.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            MeshRenderer mr_player = other.gameObject.GetComponentInChildren<MeshRenderer>();
            Material[] playerMaterial = mr_player.materials;


            //foreach (Material m_material in playerMaterial)
            //{
            if (!playerMaterial[0].name.Contains(m_name[0].ToLower()) && !playerMaterial[0].name.Contains(m_name[0].ToLower()))
                {
                    if (bc_door)
                        bc_door.isTrigger = false;
                }
            //}
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }
    */

    private void OnCollisionExit(Collision collision)
    {
        bc_door.isTrigger = true;
    }
}
