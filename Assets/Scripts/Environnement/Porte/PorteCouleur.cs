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

            MeshRenderer mr_door = gameObject.GetComponent<MeshRenderer>();

            Material m_door = mr_door.material;
            
            string[] test = m_door.name.Split(' ');


            Debug.Log(mr_door.name);

            foreach (Material m_material in playerMaterial)
            {
                if (m_material.name.Contains(test[0].ToLower()))
                    Debug.Log("Ouverture");

            }
        }
    }
}
