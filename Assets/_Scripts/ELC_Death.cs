using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Death : MonoBehaviour
{
    private ELC_LastChekpoint LastCheckpointScript;

    private void Start()
    {
        LastCheckpointScript = gameObject.GetComponent<ELC_LastChekpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Contamination")
        {
            Debug.Log("Touche l'ennemi");
            transform.position = LastCheckpointScript.CheckPointTransform;
        }
    }
}
