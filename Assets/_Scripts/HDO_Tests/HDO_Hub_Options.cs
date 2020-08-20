﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HDO_Hub_Options : MonoBehaviour
{
    BoxCollider2D box;
    BoxCollider2D[] result = new BoxCollider2D[1];
    [SerializeField]
    ContactFilter2D eliza;

    public int whatScene;
    int touched;

    // Start is called before the first frame update
    void Start()
    {
        
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        touched = Physics2D.OverlapCollider(box, eliza, result);

        if(touched >= 1 && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            SceneManager.LoadScene(whatScene);
        }
    }
}