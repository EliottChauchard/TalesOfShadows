using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Levier : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSummon;
    [SerializeField]
    private GameObject objectToDesactivate;
    [SerializeField]
    private GameObject objectWithAnimationToTrigger;
    [SerializeField]
    private GameObject objectWithAnimationToTrigger2;
    [SerializeField]
    private GameObject objectWithAnimationToTrigger3;
    private Animator objectAnimator;

    private Animator animator;
    [SerializeField]
    private GameObject DoorToTrigger;

    private ELC_OpenDoor openDoorScript;

    [SerializeField]
    private string animationName;
    [SerializeField]
    private bool hasAlreadyBeenActivated = false;
    [SerializeField]
    private bool isTimed;
    [SerializeField]
    private float timeBeforeTurnOff;
    [SerializeField]
    public bool timerIsOn;
    public bool isActivated;

    private void Start()
    {
        if(DoorToTrigger != null)
        {
            openDoorScript = DoorToTrigger.GetComponent<ELC_OpenDoor>();
        }
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorToTrigger != null)
        {
            openDoorScript.doorIsOpen = isActivated;
        }

        if (isActivated == true && isTimed == false)
        {
            animator.SetBool("SwitchBasicOn", true);
            animator.SetBool("SwitchBasicOff", false);

            SummonGameObject(true);

            DesactivateGameObject(false);

            ActivateAnimator(true);

            if (hasAlreadyBeenActivated == false)
            {
                GlobalScoreValues.activateBasicLever += 1;
                hasAlreadyBeenActivated = true;
            }
        }
        else if(isActivated == false && isTimed == false)
        {
            animator.SetBool("SwitchBasicOff", true);
            animator.SetBool("SwitchBasicOn", false);

            SummonGameObject(false);

            DesactivateGameObject(true);

            ActivateAnimator(false);
        }
        else if (isActivated == true && isTimed == true && timerIsOn == false)
        {
            animator.SetBool("SwitchTimedOn", true);
            animator.SetBool("SwitchTimedOff", false);

            StartCoroutine("ActivationTime");

            SummonGameObject(true);

            DesactivateGameObject(false);

            ActivateAnimator(true);
        }
        else if (isActivated == false && isTimed == true)
        {
            animator.SetBool("SwitchTimedOff", true);

            SummonGameObject(false);

            DesactivateGameObject(true);

            ActivateAnimator(false);
        }
    }

    void SummonGameObject(bool isEnable)
    {
        if(objectToSummon != null)
        {
            objectToSummon.GetComponent<SpriteRenderer>().enabled = isEnable;
            objectToSummon.GetComponent<BoxCollider2D>().enabled = isEnable;
        }
    }
    void DesactivateGameObject(bool isActivated)
    {
        if(objectToDesactivate != null)
        {
            objectToDesactivate.SetActive(isActivated);
        }
    }
    void ActivateAnimator(bool enable)
    {
        if (objectWithAnimationToTrigger != null)
        {
            objectAnimator = objectWithAnimationToTrigger.GetComponent<Animator>();
            objectAnimator.SetBool(animationName, enable);
            objectAnimator = objectWithAnimationToTrigger2.GetComponent<Animator>();
            objectAnimator.SetBool(animationName, enable);
            objectAnimator = objectWithAnimationToTrigger3.GetComponent<Animator>();
            objectAnimator.SetBool(animationName, enable);
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
