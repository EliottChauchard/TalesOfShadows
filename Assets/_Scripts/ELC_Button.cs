using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Button : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ELC_OpenDoor doorScript;

    [SerializeField]
    private GameObject DoorToTrigger;

    [SerializeField]
    private Sprite ButtonON;
    [SerializeField]
    private Sprite ButtonOFF;

    [SerializeField]
    private bool isActivate;
    [SerializeField]
    private string tagOfTheObject;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        doorScript = DoorToTrigger.GetComponent<ELC_OpenDoor>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isActivate == true)
        {
            spriteRenderer.sprite = ButtonON;
            doorScript.doorIsOpen = true;
        }
        else
        {
            spriteRenderer.sprite = ButtonOFF;
            doorScript.doorIsOpen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tagOfTheObject = collision.tag;
        if(tagOfTheObject == "SensibleObject")
        {
            isActivate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tagOfTheObject = "Nothing";
        if(collision.tag == "SensibleObject")
        {
            isActivate = false;
        }
    }
}
