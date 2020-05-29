using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_SoundVolume : MonoBehaviour
{
    static public float soundVolume;

    // Update is called once per frame
    void Update()
    {
        soundVolume = this.gameObject.GetComponent<Slider>().value;
    }
}
