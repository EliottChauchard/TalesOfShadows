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

    [SerializeField]
    private GameObject cable1;
    [SerializeField]
    private GameObject cable2;
    [SerializeField]
    private GameObject cable3;
    [SerializeField]
    private GameObject cable4;
    [SerializeField]
    private GameObject cable5;
    [SerializeField]
    private GameObject cable6;
    [SerializeField]
    private GameObject cable7;
    [SerializeField]
    private GameObject cable8;


    private void Start()
    {
        playerHaveEnoughKey = false;
        DoorScript = ControledDoor.GetComponent<ELC_OpenDoor>();
        EnableLight(Color.black);
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
                EnableLight(Color.yellow);
                if (numberOfKeyNeeded == 1)
                {
                    GlobalScoreValues.activateOneKeyMachine += 1;
                    hasAlreadyBeenActivated = true;
                    changeCablesColour(Color.white);
                }
                if (numberOfKeyNeeded == 2)
                {
                    GlobalScoreValues.activateTwoKeyMachine += 1;
                    hasAlreadyBeenActivated = true;
                    changeCablesColour(Color.white);
                }
                if (numberOfKeyNeeded == 3)
                {
                    GlobalScoreValues.activateThreeKeyMachine += 1;
                    hasAlreadyBeenActivated = true;
                    changeCablesColour(Color.white);
                }
            }
        }

    }

    void changeCablesColour(Color newColor)
    {

        if (hasAlreadyBeenActivated == true)
        {
            if (cable1 != null)
            {
                cable1.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable2 != null)
            {
                cable2.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable3 != null)
            {
                cable3.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable4 != null)
            {
                cable4.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable5 != null)
            {
                cable5.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable6 != null)
            {
                cable6.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable7 != null)
            {
                cable7.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
            if (cable8 != null)
            {
                cable8.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
            }
        }
    }

    void EnableLight(Color color)
    {
        this.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", color);
    }
}
