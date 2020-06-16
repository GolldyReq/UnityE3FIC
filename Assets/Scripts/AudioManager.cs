using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sons;

    void Awake()
    {
        foreach(Sound s in sons)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string nom)
    {
        Sound s = Array.Find(sons, son => son.nom == nom);
        if (s == null)
        {
            Debug.LogWarning("Son : " + nom +" n'a pas été trouvé");
            return;
        }
        s.source.Play();
    }   
}
