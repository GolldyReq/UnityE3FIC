using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem m_particule;
    [Range(0, 50)]
    [SerializeField] int m_RangeX;
    [Range(0, 50)]
    [SerializeField] int m_RangeZ;
    [SerializeField] float m_Frequence;
    [SerializeField] int m_RotateParticuleX;
    [SerializeField] int m_RotateParticuleY;
    [SerializeField] int m_RotateParticuleZ;
    [SerializeField] int m_SizeParticule=1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchParticule(m_Frequence));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LaunchParticule(float duree)
    {
        while (true)
        {
            Vector3 RandVect = new Vector3(gameObject.transform.position.x + Random.Range(-m_RangeX, m_RangeX), gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-m_RangeZ, m_RangeZ));
            ParticleSystem newParticule = Instantiate(m_particule, RandVect, Quaternion.identity);
            newParticule.transform.localScale = new Vector3(m_SizeParticule, m_SizeParticule, m_SizeParticule);
            if(m_RotateParticuleX!=0 || m_RotateParticuleY != 0 || m_RotateParticuleZ != 0)
                newParticule.transform.Rotate( new Vector3(m_RotateParticuleX,m_RotateParticuleY,m_RotateParticuleZ));
            newParticule.Play();
            Destroy(newParticule.gameObject, 3f);
            //Destroy(newProjectile, 5f);
            //yield return null;
            yield return new WaitForSeconds(duree);
        }
    }
}
