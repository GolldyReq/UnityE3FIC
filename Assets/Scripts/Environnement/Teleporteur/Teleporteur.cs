using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{

    [SerializeField] Transform m_PlayerPosTeleport;
    [SerializeField] Transform m_CameraPosTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //collider.gameObject.transform.position = m_PlayerPosTeleport.position;
            GameObject camera = GameObject.Find("Camera");
            //Version Debug
            if (camera == null)
                camera = GameObject.Find("CameraDebug");
            collider.gameObject.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collider.gameObject.transform.parent.position = m_PlayerPosTeleport.position;
            Debug.Log(camera.name);
            camera.transform.position = m_CameraPosTeleport.position;
        }
    }
}
