using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteCouleur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MeshRenderer mr_player = collision.gameObject.GetComponentInChildren<MeshRenderer>();
            Material[] playerMaterial = mr_player.materials;

            BoxCollider bcDoor = gameObject.GetComponent<BoxCollider>();
            bcDoor.enabled = true;
            Material m_door = gameObject.GetComponent<MeshRenderer>().material;
            
            string[] test = m_door.name.Split(' ');

            

            foreach (Material m_material in playerMaterial)
            {
                if (m_material.name.Contains(test[0].ToLower()))
                {
                    Debug.Log("Ouverture");
                    
                    if (bcDoor)
                        bcDoor.enabled = false;
                    
                }
            }
        }
    }
}
