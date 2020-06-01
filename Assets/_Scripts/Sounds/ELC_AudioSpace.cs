﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ELC_AudioSpace : MonoBehaviour
{
    private GameObject playerGameObject;
    private Vector2 playerPosition;
    private Vector2 objectPosition;
    private AudioSource audioSource;

    [SerializeField]
    private Vector2 distanceBtwThem;
    [SerializeField]
    private float distanceMax;
    [SerializeField]
    private bool isPlayingSound;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerGameObject.GetComponent<Transform>().position;
        objectPosition = this.GetComponent<Transform>().position;

        distanceBtwThem = objectPosition - playerPosition;

        if(distanceBtwThem.x < distanceMax && distanceBtwThem.x > -distanceMax && distanceBtwThem.y < distanceMax && distanceBtwThem.y > -distanceMax && isPlayingSound == false)
        {
            Debug.Log("CanPlaySound");
            audioSource.Play();
            isPlayingSound = true;
        }
        else if (distanceBtwThem.x > distanceMax || distanceBtwThem.x < -distanceMax || distanceBtwThem.y > distanceMax || distanceBtwThem.y < -distanceMax && isPlayingSound == true)
        {
            Debug.Log("StopPlaySound");
            isPlayingSound = false;
            audioSource.Stop();
        }

        if(isPlayingSound == true)
        {
            if (distanceBtwThem.x > 0 && distanceBtwThem.y > 0)
            {
                audioSource.volume = 1 - ((distanceBtwThem.x + distanceBtwThem.y) / distanceMax);
            }
            else if (distanceBtwThem.x < 0 && distanceBtwThem.y > 0)
            {
                audioSource.volume = 1 + ((distanceBtwThem.x - distanceBtwThem.y) / distanceMax);
            }
            else if (distanceBtwThem.x > 0 && distanceBtwThem.y < 0)
            {
                audioSource.volume = 1 - ((distanceBtwThem.x - distanceBtwThem.y)  / distanceMax);
            }
            else if (distanceBtwThem.x < 0 && distanceBtwThem.y < 0)
            {
                audioSource.volume = 1 + ((distanceBtwThem.x + distanceBtwThem.y) / distanceMax);
            }
        }
    }
}
