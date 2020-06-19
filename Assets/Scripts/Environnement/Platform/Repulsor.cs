using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsor : MonoBehaviour
{
    [SerializeField] bool m_OnX;
    [SerializeField] bool m_OnY;
    [SerializeField] bool m_OnZ;

    [Tooltip ("Direction et puissance de la repulsion")]
    [SerializeField] int m_DirectionX;
    [SerializeField] int m_DirectionY;
    [SerializeField] int m_DirectionZ;

    [Tooltip("Si oui affecte aussi le joueur")]
    [SerializeField] bool m_PlayerAffect;

    private Vector3 vectRepulsion;

    // Start is called before the first frame update
    void Start()
    {
        vectRepulsion = Vector3.zero;
        if (m_OnX)
            vectRepulsion = vectRepulsion + Vector3.right*m_DirectionX;
        if (m_OnY)
            vectRepulsion = vectRepulsion + Vector3.up*m_DirectionY;
        if (m_OnZ)
            vectRepulsion = vectRepulsion + Vector3.forward*m_DirectionZ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !m_PlayerAffect)
            return;
        other.gameObject.GetComponent<Rigidbody>().AddForce(vectRepulsion, ForceMode.Impulse);
    }
}
