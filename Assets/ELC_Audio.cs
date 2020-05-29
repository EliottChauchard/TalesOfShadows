using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Audio : MonoBehaviour
{
    
    void Update()
    {
        AudioListener.volume = ELC_SoundVolume.soundVolume;
    }
}
