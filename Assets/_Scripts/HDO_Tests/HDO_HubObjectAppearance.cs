﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class HDO_HubObjectAppearance : MonoBehaviour
{
    public int number;

    public GameObject volume, virtualCam;
    CinemachineVirtualCamera cvc;
    Transform credits;
    Transform elisa;

    // Start is called before the first frame update
    void Start()
    {
        cvc = virtualCam.GetComponent<CinemachineVirtualCamera>();
        credits = GameObject.Find("Credits").GetComponent<Transform>();
        elisa = GameObject.Find("Elisa").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(number);
        if(number == 4)
        {
            SceneManager.LoadScene(4);
        }
        if(number == 6)
        {
            SceneManager.LoadScene(6);
        }
        if(number == 5)
        {
            cvc.Follow = credits;
        }
        else
        {
            cvc.Follow = elisa;
        }
    }
}