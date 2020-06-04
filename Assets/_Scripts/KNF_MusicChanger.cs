using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNF_MusicChanger : MonoBehaviour
{
    public AudioSource audioMusik;
    private int count = 0;
    public AudioClip cityMusic;
    public AudioClip enviroMusic;
    [Range(0f, 1f)]
    public float enviromusikVolume;
    [Range(0f, 1f)]
    public float citymusikVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")))
        {
            audioMusik.volume = 0.05f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")) && (audioMusik.clip == cityMusic))
        {
            audioMusik.clip = enviroMusic;
            audioMusik.Play();
            audioMusik.volume = enviromusikVolume;
        }
        if ((collision.gameObject.CompareTag("Player")) && (audioMusik.clip == enviroMusic))
        {
            audioMusik.clip = cityMusic;
            audioMusik.Play();
            audioMusik.volume = citymusikVolume;
        }
    }
}
