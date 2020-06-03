using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Audio : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<ELC_AudioManager>().Play("MenuMusic", false);
        AudioListener.volume = PlayerPrefs.GetFloat("GlobalVolume");
    }
    void Update()
    {
        
    }
}
