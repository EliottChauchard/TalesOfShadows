                    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_SoundVolume : MonoBehaviour
{
    static public float soundVolume;

    private void Start()
    {
        this.gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("GlobalVolume");
    }
    // Update is called once per frame
    void Update()
    {
        soundVolume = this.gameObject.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("GlobalVolume", soundVolume);
    }
}
