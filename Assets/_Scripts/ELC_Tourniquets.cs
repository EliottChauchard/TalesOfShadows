using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Tourniquets : MonoBehaviour
{
    [SerializeField]
    private GameObject plateformToTrigger;
    private ELC_MovingPlateform plateformScript;

    [SerializeField]
    private GameObject doorToTrigger;
    private ELC_OpenDoor openDoorScript;

    [SerializeField]
    private bool canTrigger = true;
    [SerializeField]
    private bool isActivated;
    [SerializeField]
    private float timeBeforeDisable;

    
    void Start()
    {
        if(plateformToTrigger != null)
        {
            plateformScript = plateformToTrigger.GetComponent<ELC_MovingPlateform>();
        }

        if(doorToTrigger != null)
        {
            openDoorScript = doorToTrigger.GetComponent<ELC_OpenDoor>();
        }
    }
    
    void Update()
    {
        
    }

    public IEnumerator Activate()
    {
        if (canTrigger == true)
        {
            canTrigger = false;
            if (plateformToTrigger != null)
            {
                plateformScript.startMoving();
                plateformScript.GoToPoint();
            }
            if (doorToTrigger != null)
            {
                openDoorScript.doorIsOpen = true;
            }

            yield return new WaitForSeconds(timeBeforeDisable);

            if (plateformToTrigger != null)
            {
                plateformScript.Return();
            }
            if (doorToTrigger != null)
            {
                openDoorScript.doorIsOpen = false;
            }
            canTrigger = true;
        }
    }
}
