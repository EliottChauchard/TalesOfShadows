using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLC_PathHiderScript : MonoBehaviour
{
    public bool discovered;
    public GameObject spriteMask;

    void Update()
    {
        if(discovered)
        {
            spriteMask.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
