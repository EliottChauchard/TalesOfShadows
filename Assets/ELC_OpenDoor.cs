using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_OpenDoor : MonoBehaviour
{
    public bool doorIsOpen = false;
    private BoxCollider2D BoxCollider;
    

    // Update is called once per frame
    void Update()
    {
        BoxCollider = this.GetComponent<BoxCollider2D>();

        if (doorIsOpen == true)
        {
            BoxCollider.enabled = false;
        }
        else
        {
            BoxCollider.enabled = true;
        }
    }
}
