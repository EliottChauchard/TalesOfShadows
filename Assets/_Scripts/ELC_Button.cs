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
            ActivateCables(Color.white);
        }
        else
        {
            spriteRenderer.sprite = ButtonOFF;
            doorScript.doorIsOpen = false;
            ActivateCables(Color.black);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tagOfTheObject = collision.tag;
        if(tagOfTheObject == "SensibleObject" || tagOfTheObject == "Monster" || tagOfTheObject == "Player")
        {
            isActivate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tagOfTheObject = "Nothing";
        if(collision.tag == "SensibleObject" || collision.tag == "Monster" || collision.tag == "Player")
        {
            isActivate = false;
        }
    }

    void ActivateCables(Color newColor)
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
