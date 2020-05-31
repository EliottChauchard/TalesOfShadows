using UnityEngine.Audio;
using System;
using UnityEngine;

public class ELC_AudioManager : MonoBehaviour
{
    public ELC_Sounds[] sounds;

   
    void Awake()
    {
        foreach(ELC_Sounds SoundsScript in sounds)
        {
            SoundsScript.source = gameObject.AddComponent<AudioSource>();
            SoundsScript.source.clip = SoundsScript.clip;

            SoundsScript.source.volume = SoundsScript.volume;
            SoundsScript.source.pitch = SoundsScript.pitch;
        }
    }

    public void Play(string name)
    {
        ELC_Sounds s = Array.Find(sounds, ELC_Sounds => ELC_Sounds.name == name);
        s.source.Play();
    }
}
