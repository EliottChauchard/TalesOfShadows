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
    private GameObject objectToDesactivate2;
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
    private float timeBeforeTurnOffCinematic;
    [SerializeField]
    public bool timerIsOn;
    [SerializeField]
    public bool isCinematicLever;
    public bool isActivated;

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
    [SerializeField]
    private GameObject cable9;


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

            changeGlowColor(Color.white);

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

            changeGlowColor(Color.black);

            DesactivateGameObject(true);

            ActivateAnimator(false);
        }
        else if (isActivated == true && isTimed == true && timerIsOn == false)
        {
            animator.SetBool("SwitchTimedOn", true);
            animator.SetBool("SwitchTimedOff", false);

            StartCoroutine("ActivationTime");

            SummonGameObject(true);

            changeGlowColor(Color.white);

            DesactivateGameObject(false);

            ActivateAnimator(true);
        }
        else if (isActivated == false && isTimed == true)
        {
            animator.SetBool("SwitchTimedOff", true);

            SummonGameObject(false);

            changeGlowColor(Color.black);

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
            if(objectToDesactivate2 != null)
            {
                objectToDesactivate2.SetActive(isActivated);
            }
        }
        
    }
    void ActivateAnimator(bool enable)
    {
        if (objectWithAnimationToTrigger != null)
        {
            objectAnimator = objectWithAnimationToTrigger.GetComponent<Animator>();
            objectAnimator.SetBool(animationName, enable);

            if(objectWithAnimationToTrigger2 != null)
            {
                objectAnimator = objectWithAnimationToTrigger2.GetComponent<Animator>();
                objectAnimator.SetBool(animationName, enable);
            }

            if(objectWithAnimationToTrigger3 != null)
            {
                objectAnimator = objectWithAnimationToTrigger3.GetComponent<Animator>();
                objectAnimator.SetBool(animationName, enable);
            }
        }
    }

    void changeGlowColor(Color newColor)
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
        if (cable9 != null)
        {
            cable9.GetComponent<Renderer>().material.SetColor("Color_39D6A3EA", newColor);
        }
    }

    IEnumerator ActivationTime()
    {
        timerIsOn = true;
        animator.SetBool("TimeIsLooping", true);
        this.GetComponent<AudioSource>().Play();
        if(isCinematicLever == true)
        {
            yield return new WaitForSeconds(timeBeforeTurnOffCinematic);
            isCinematicLever = false;
            this.GetComponent<AudioSource>().Stop();
        }
        else if(isCinematicLever == false)
        {
            yield return new WaitForSeconds(timeBeforeTurnOff);
            this.GetComponent<AudioSource>().Stop();
        }
        animator.SetBool("SwitchTimedOn", false);
        animator.SetBool("TimeIsLooping", false);
        animator.SetBool("SwitchTimedOff", true);
        
        isActivated = false;
        timerIsOn = false;
    }
}
