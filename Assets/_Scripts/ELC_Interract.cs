﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Interract : MonoBehaviour
{

    private ELC_DoorInterruptor DoorInterruptorScript;
    private ELC_Collectibles CollectiblesScript;
    private ELC_LastChekpoint CheckpointValueScript;

    private string tagOfCollidedObject;

    private Vector3 checkpointTransform;

    // Update is called once per frame
    void Update()
    {
        CollectiblesScript = gameObject.GetComponent<ELC_Collectibles>();
        CheckpointValueScript = gameObject.GetComponent<ELC_LastChekpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        tagOfCollidedObject = collide.gameObject.tag;

        if (tagOfCollidedObject == "DoorInterruptor")
        {
            DoorInterruptorScript = collide.gameObject.GetComponent<ELC_DoorInterruptor>();

            if (DoorInterruptorScript.numberOfKeyNeeded <= CollectiblesScript.numberOfKeys)
            {
                tagOfCollidedObject = "Nothing";
                DoorInterruptorScript.playerHaveEnoughKey = true;
                collide.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                CollectiblesScript.numberOfKeys = CollectiblesScript.numberOfKeys - DoorInterruptorScript.numberOfKeyNeeded;
            }
        }
        else if(tagOfCollidedObject == "Checkpoint")
        {
            checkpointTransform = new Vector3(collide.gameObject.transform.localPosition.x, collide.gameObject.transform.localPosition.y, collide.gameObject.transform.localPosition.z);
        }

        CheckpointValueScript.CheckPointTransform = checkpointTransform;
    }
}
