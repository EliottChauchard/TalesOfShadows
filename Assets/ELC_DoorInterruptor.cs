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
            statutOfTheDoor = true;;
        }
    }
}
