using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_DoorInterruptor : MonoBehaviour
{

    ELC_OpenDoor DoorScript;

    [SerializeField]
    public int numberOfKeyNeeded;
    public bool playerHaveEnoughKey;
    [SerializeField]
    private bool hasAlreadyBeenActivated;


    [SerializeField]
    GameObject ControledDoor;
    private bool statutOfTheDoor;



    private void Start()
    {
        playerHaveEnoughKey = false;
        DoorScript = ControledDoor.GetComponent<ELC_OpenDoor>();
    }


    // Update is called once per frame
    void Update()
    {
        DoorScript.doorIsOpen = statutOfTheDoor;
        if (playerHaveEnoughKey == true)
        {
            statutOfTheDoor = true;
            if(hasAlreadyBeenActivated == false)
            {
                if(numberOfKeyNeeded == 1)
                {
                    GlobalScoreValues.activateOneKeyMachine += 1;
                    hasAlreadyBeenActivated = true;
                }
                if (numberOfKeyNeeded == 2)
                {
                    GlobalScoreValues.activateTwoKeyMachine += 1;
                    hasAlreadyBeenActivated = true;
                }
                if (numberOfKeyNeeded == 3)
                {
                    GlobalScoreValues.activateThreeKeyMachine += 1;
                    hasAlreadyBeenActivated = true;
                }
            }
        }
    }
}
