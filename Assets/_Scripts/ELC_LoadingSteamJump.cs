using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_LoadingSteamJump : MonoBehaviour
{
    ELC_SteamJump steamJumpScript;
    private float charge;
    private bool isChargingSJ;
    [SerializeField]
    public float limitY;

    public Vector2 jumpDirection;

    void Start()
    {
        steamJumpScript = GetComponentInParent<ELC_SteamJump>();
    }

    void Update()
    {
        isChargingSJ = steamJumpScript.isChargingSteamJump;
        charge = steamJumpScript.charge;

        jumpDirection = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 0.5f);

        if(jumpDirection.y < limitY)
        {
            jumpDirection.y = limitY;
        }

        Debug.DrawRay(transform.localPosition, jumpDirection, Color.blue);
    }
}