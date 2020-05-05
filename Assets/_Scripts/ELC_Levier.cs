using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Levier : MonoBehaviour
{
    [SerializeField]
    private GameObject DoorToTrigger;
    [SerializeField]
    private Sprite SpriteBasicON;
    [SerializeField]
    private Sprite SpriteBasicOFF;
    [SerializeField]
    private Sprite SpriteTimedON;
    [SerializeField]
    private Sprite SpriteTimedOFF;

    private ELC_OpenDoor openDoorScript;
    private SpriteRenderer SpriteRenderer;

    [SerializeField]
    private bool isTimed;
    [SerializeField]
    private float timeBeforeTurnOff;
    [SerializeField]
    public bool timerIsOn;
    public bool isActivated;

    private void Start()
    {
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        openDoorScript = DoorToTrigger.GetComponent<ELC_OpenDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        openDoorScript.doorIsOpen = isActivated;

        if (isActivated == true && isTimed == false)
        {
            SpriteRenderer.sprite = SpriteBasicON;
        }
        else if(isActivated == false && isTimed == false)
        {
            SpriteRenderer.sprite = SpriteBasicOFF;
        }
        else if (isActivated == true && isTimed == true && timerIsOn == false)
        {
            SpriteRenderer.sprite = SpriteTimedON;
            StartCoroutine("ActivationTime");
        }
        else if (isActivated == false && isTimed == true)
        {
            SpriteRenderer.sprite = SpriteTimedOFF;
        }
    }

    IEnumerator ActivationTime()
    {
        timerIsOn = true;
        yield return new WaitForSeconds(timeBeforeTurnOff);
        isActivated = false;
        timerIsOn = false;
    }
}
