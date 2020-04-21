using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_LoadingSteamJump : MonoBehaviour
{
    ELC_SteamJump steamJumpScript;
    private float charge;

    public Vector2 jumpDirection;

    void Start()
    {
        steamJumpScript = GetComponentInParent<ELC_SteamJump>();
    }

    void Update()
    {
        charge = steamJumpScript.charge;
        transform.localScale = new Vector3 (charge * 0.05f, 0.1f, 1f);

        jumpDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.DrawRay(transform.localPosition, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), Color.blue);

    }
}
