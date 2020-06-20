using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int m_Puissance;
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
        collision.gameObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.up*m_Puissance, ForceMode.Impulse);
    }
}
