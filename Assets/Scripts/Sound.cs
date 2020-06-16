using UnityEngine.Audio;
using UnityEngine;
using UnityEditor.ShaderGraph.Internal;

[System.Serializable]
public class Sound 
{
    public AudioClip clip;

    public string nom;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
