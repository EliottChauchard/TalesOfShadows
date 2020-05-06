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
    private string tagOfCollidedObject;

    private Vector3 checkpointTransform;

    // Update is called once per frame
    void Update()
    {
        CollectiblesScript = gameObject.GetComponent<ELC_Collectibles>();
        CheckpointValueScript = gameObject.GetComponent<ELC_LastChekpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collide) //Cette fonction ne trigger qu'une fois que le joueur entre en collision avec l'objet et n'agit que pendant 1 frame, si on veut un truc où il faut vérif que le joueur soit dans l'objet + qu'il appuie sur une touche il vaut mieux uiliser OnTriggerStay2D (je crois que c'est ça)
    {
        tagOfCollidedObject = collide.gameObject.tag;

        if (tagOfCollidedObject == "DoorInterruptor")
        {
            DoorInterruptorScript = collide.gameObject.GetComponent<ELC_DoorInterruptor>();

            if (DoorInterruptorScript.numberOfKeyNeeded <= CollectiblesScript.numberOfKeys)
            {
                DoorInterruptorScript.playerHaveEnoughKey = true;
                collide.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                CollectiblesScript.numberOfKeys = CollectiblesScript.numberOfKeys - DoorInterruptorScript.numberOfKeyNeeded;
            }
        }
        else if(tagOfCollidedObject == "Checkpoint")
        {
            checkpointTransform = new Vector3(collide.gameObject.transform.localPosition.x, collide.gameObject.transform.localPosition.y, collide.gameObject.transform.localPosition.z);
            CheckpointValueScript.CheckPointTransform = checkpointTransform;
        }
        else if(tagOfCollidedObject == "Levier")
        {
            LevierScript = collide.gameObject.GetComponent<ELC_Levier>();
            if(LevierScript.timerIsOn == false)
            {
                LevierScript.isActivated = !LevierScript.isActivated;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tagOfCollidedObject = "Nothing";
    }
}
