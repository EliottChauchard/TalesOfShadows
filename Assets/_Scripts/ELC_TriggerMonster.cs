using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_TriggerMonster : MonoBehaviour
{
    public GameObject playerGameObject;

    public bool playerIsInside;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsInside = true;
            playerGameObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIsInside = false;
        }
    }
}
