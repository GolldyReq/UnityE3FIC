using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRotate : MonoBehaviour
{
    [SerializeField] ParticleSystem m_particule;

    [SerializeField] bool m_RotateOnX;
    [SerializeField] bool m_RotateOnY;
    [SerializeField] bool m_RotateOnZ;

    [SerializeField] GameObject[] m_DestroyObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_RotateOnX)
            transform.Rotate(Vector3.right);
        if (m_RotateOnY)
            transform.Rotate(Vector3.up);
        if (m_RotateOnZ)
            transform.Rotate(Vector3.forward);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ParticleSystem newParticule = Instantiate(m_particule, gameObject.transform.position, Quaternion.identity);

            newParticule.transform.localScale = new Vector3(1f, 1f, 1f);
            newParticule.Play();

            Destroy(newParticule.gameObject, 2f);
            if (m_DestroyObject.Length==0)
                Destroy(gameObject);
            else
            {

                for(int i = 0; i<m_DestroyObject.Length;i++)
                {
                    Destroy(m_DestroyObject[i]);
                }
            }
        }
    }
}
