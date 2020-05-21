using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_LoadingBar : MonoBehaviour
{
    ELC_SteamJump steamJumpScript;
    private float charge;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    

    void Start()
    {
        steamJumpScript = GetComponentInParent<ELC_SteamJump>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        charge = steamJumpScript.charge;
        if (charge > 0)
        {
            animator.SetBool("IsChargingSteamJump", true);
            spriteRenderer.enabled = true;
        }
        else
        {
            animator.SetBool("IsChargingSteamJump", false);
            spriteRenderer.enabled = false;
        }
    }
}
