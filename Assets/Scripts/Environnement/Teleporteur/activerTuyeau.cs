using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activerTuyeau : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject m_t1;
    [SerializeField] GameObject m_t2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");

        if (other.gameObject.CompareTag("Player"))  
        {
            Debug.Log("OnCollisionEnter with Player");
                                                         
            m_t1.SetActive(true);
            m_t2.SetActive(true);

        }
    }
}
