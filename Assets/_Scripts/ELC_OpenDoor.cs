using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_OpenDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private bool horizontalDoor;
    [SerializeField]
    private bool verticalDoor;
    private bool hasAlreadyBeenOpen;

    public bool doorIsOpen = false;

    private BoxCollider2D BoxCollider;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider = this.GetComponent<BoxCollider2D>();

        if (doorIsOpen == true && hasAlreadyBeenOpen == false)
        {
            BoxCollider.enabled = false;
            spriteRenderer.enabled = false;
            hasAlreadyBeenOpen = true;
            this.GetComponent<AudioSource>().Play();

        }
        else if(doorIsOpen == false)
        {
            BoxCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
    }
}
