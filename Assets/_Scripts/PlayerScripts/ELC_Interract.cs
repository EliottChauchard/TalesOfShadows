using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Interract : MonoBehaviour
{
    
    private ELC_DoorInterruptor DoorInterruptorScript;
    private ELC_Collectibles CollectiblesScript;
    private ELC_LastChekpoint CheckpointValueScript;
    private ELC_Levier LevierScript;
    [SerializeField]
    private GameObject gameObjectDetected;

    [SerializeField]
    private string tagOfCollidedObject;

    private Vector3 checkpointTransform;

    // Update is called once per frame
    void Update()
    {
        CollectiblesScript = gameObject.GetComponent<ELC_Collectibles>();
        CheckpointValueScript = gameObject.GetComponent<ELC_LastChekpoint>();

        if (tagOfCollidedObject == "DoorInterruptor" )
        {
            DoorInterruptorScript = gameObjectDetected.GetComponent<ELC_DoorInterruptor>();

            if (DoorInterruptorScript.numberOfKeyNeeded <= CollectiblesScript.numberOfKeys && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1)))
            {
                DoorInterruptorScript.playerHaveEnoughKey = true;
                gameObjectDetected.GetComponent<BoxCollider2D>().enabled = false;
                CollectiblesScript.numberOfKeys = CollectiblesScript.numberOfKeys - DoorInterruptorScript.numberOfKeyNeeded;
                FindObjectOfType<ELC_AudioManager>().Play("DoorInterruptor", false);
                FindObjectOfType<ELC_ScreenShake>().ScreenShake(1f, 0.04f);
            }
        }
        else if (tagOfCollidedObject == "Checkpoint")
        {
            checkpointTransform = new Vector3(gameObjectDetected.transform.position.x, gameObjectDetected.transform.position.y, gameObjectDetected.transform.position.z);
            CheckpointValueScript.CheckPointTransform = checkpointTransform;
        }
        else if (tagOfCollidedObject == "Levier")
        {
            Debug.Log("Levier detect");
            LevierScript = gameObjectDetected.GetComponent<ELC_Levier>();
            if (LevierScript.timerIsOn == false && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1)))
            {
                Debug.Log("Levier activé");
                LevierScript.isActivated = !LevierScript.isActivated;
                FindObjectOfType<ELC_AudioManager>().Play("ActivateLever", false);
            }
        }
        else if(tagOfCollidedObject == "SpecialInterruptor")
        {
            Debug.Log("Interruptor Detected");
            if (gameObjectDetected.GetComponent<ELC_SpecialInterruptor>().isActivated == false && CollectiblesScript.numberOfSpecialKeys > 0f && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1)))
            {
                gameObjectDetected.GetComponent<ELC_SpecialInterruptor>().isActivated = true;
                CollectiblesScript.numberOfSpecialKeys -= 1f;
                FindObjectOfType<ELC_AudioManager>().Play("DoorInterruptor", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        tagOfCollidedObject = collide.gameObject.tag;
        gameObjectDetected = collide.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tagOfCollidedObject = "Nothing";
    }
}
