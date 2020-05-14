using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    private ParticleSystem m_Effect;
    // Start is called before the first frame update
    void Start()
    {
        m_Effect = gameObject.GetComponentInChildren<ParticleSystem>();
        //m_Effect = gameObject.GetComponentInChildren<ParticleSystem>();
        m_Effect.Pause();

        /*
        // A simple particle material with no texture.
        Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

        // Create a green Particle System.
        var go = new GameObject("Particle System");
        go.transform.Rotate(-90, 0, 0); // Rotate so the system emits upwards.
        m_Effect = go.AddComponent<ParticleSystem>();
        go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        var mainModule = m_Effect.main;
        mainModule.startColor = Color.green;
        mainModule.startSize = 0.5f;
        */
        // Every 2 secs we will emit.
        //InvokeRepeating("DoEmit", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward);
    }

    private void DoEmit()
    {
        Debug.Log("Lancement particle");
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        m_Effect.Emit(emitParams, 10);
        m_Effect.Play();
    }


    //Le joueur récupére la piéce 
    private void OnTriggerEnter(Collider other)
    {
        m_Effect.Play();
        MeshRenderer mr_visible  = gameObject.GetComponent<MeshRenderer>();
        mr_visible.enabled = false;
        Destroy(gameObject, 1f);
    }
}
