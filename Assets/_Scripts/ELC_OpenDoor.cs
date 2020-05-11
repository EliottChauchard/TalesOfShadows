using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_OpenDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite DoorOpen;
    [SerializeField]
    private Sprite DoorClose;

    public bool doorIsOpen = false;

    private BoxCollider2D BoxCollider;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider = this.GetComponent<BoxCollider2D>();

        if (doorIsOpen == true)
        {
            BoxCollider.enabled = false;
            spriteRenderer.sprite = DoorOpen;
        }
        else
        {
            BoxCollider.enabled = true;
            spriteRenderer.sprite = DoorClose;
        }
    }
}
