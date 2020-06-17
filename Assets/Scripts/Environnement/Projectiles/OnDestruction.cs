using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestruction : MonoBehaviour
{

    [SerializeField] ParticleSystem m_particule;
    // Start is called before the first frame update
    void Start()
    {
        //m_particule.Pause();
        Debug.Log("Yes sir pause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DoEmit()
    {
        Debug.Log("Lancement particle");
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        m_particule.Emit(emitParams, 10);
        m_particule.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plateforme") || other.gameObject.CompareTag("Decor"))
        {
            ParticleSystem newParticule = Instantiate(m_particule, gameObject.transform.position, Quaternion.identity);

            newParticule.transform.localScale = new Vector3(1f, 1f, 1f); 
            newParticule.Play();

            Destroy(newParticule.gameObject,2f);
            Destroy(transform.parent.gameObject);
        }
    }
}
