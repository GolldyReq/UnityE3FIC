using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trou : MonoBehaviour
{
    [Tooltip ("La boule que le trou accepte")]
    [SerializeField] GameObject m_Cible;
    private bool m_IsRempli;

    [Tooltip("Point de respawn si ce n'est pas la bonne boule qui rentre")]
    [SerializeField] Transform m_Respawn;
    // Start is called before the first frame update
    void Start()
    {
        m_IsRempli = false;
        if (m_Cible == null)
            Debug.Log("Pas de cible");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boule") || other.gameObject.CompareTag("Killable"))
        {
            if (m_Cible == null)
                m_IsRempli = true;
            else
            {
                if (other.transform.name != m_Cible.name)
                    other.gameObject.transform.position = m_Respawn.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_IsRempli = false;
    }

    public bool IsRempli()
    {
        return m_IsRempli;
    }

}
