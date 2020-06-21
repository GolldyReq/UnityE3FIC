using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager m_Instance;
    public static AudioManager Instance { get { return m_Instance; } }

    public Sound[] sons;

    void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
        foreach (Sound s in sons)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public static void Play(string nom)
    {
        Sound s = Array.Find(AudioManager.m_Instance.sons, son => son.nom == nom);
        if (s == null)
        {
            Debug.LogWarning("Son : " + nom +" n'a pas été trouvé");
            return;
        }
        s.source.Play();
    }
    
    public static void StopAll()
    {
        foreach(Sound son in AudioManager.m_Instance.sons)
        {
            son.source.Stop();
        }
    }
}