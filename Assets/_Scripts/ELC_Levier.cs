using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Levier : MonoBehaviour
{
    private Animator animator;
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
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        openDoorScript.doorIsOpen = isActivated;

        if (isActivated == true && isTimed == false)
        {
            SpriteRenderer.sprite = SpriteBasicON;
            animator.SetBool("SwitchBasicOn", true);
            animator.SetBool("SwitchBasicOff", false);
        }
        else if(isActivated == false && isTimed == false)
        {
            animator.SetBool("SwitchBasicOff", true);
            animator.SetBool("SwitchBasicOn", false);
            SpriteRenderer.sprite = SpriteBasicOFF;
        }
        else if (isActivated == true && isTimed == true && timerIsOn == false)
        {
            animator.SetBool("SwitchTimedOn", true);
            animator.SetBool("SwitchTimedOff", false);
            SpriteRenderer.sprite = SpriteTimedON;
            StartCoroutine("ActivationTime");
        }
        else if (isActivated == false && isTimed == true)
        {
            SpriteRenderer.sprite = SpriteTimedOFF;
            animator.SetBool("SwitchTimedOff", true);
        }
    }

    IEnumerator ActivationTime()
    {
        timerIsOn = true;
        animator.SetBool("TimeIsLooping", true);
        
        yield return new WaitForSeconds(timeBeforeTurnOff);
        animator.SetBool("SwitchTimedOn", false);
        animator.SetBool("TimeIsLooping", false);
        animator.SetBool("SwitchTimedOff", true);
        
        isActivated = false;
        timerIsOn = false;
    }
}
