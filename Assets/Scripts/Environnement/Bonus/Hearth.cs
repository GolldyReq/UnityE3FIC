using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    [SerializeField] ParticleSystem m_particule;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<Player>().GetHearth();
            ParticleSystem newParticule = Instantiate(m_particule, gameObject.transform.position, Quaternion.identity);
            newParticule.transform.localScale = new Vector3(1f, 1f, 1f);
            newParticule.Play();
            AudioManager.Play("GetHearth");
            Destroy(newParticule.gameObject, 2f);
            Destroy(gameObject);
        }
    }
}
