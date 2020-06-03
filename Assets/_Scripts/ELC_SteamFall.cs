using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SteamFall : MonoBehaviour
{
    ELC_PlayerMoves playerMoves;
    private Animator animator;

    public bool steamFallEnable;
    private bool playerIsFalling;
    private bool playerIsOnGround;
    private bool isChargingSteamJump;
    [SerializeField]
    private bool steamFuelIsFull;
    [SerializeField]
    private bool steamFuelIsHalfFull;
    [SerializeField]
    private bool steamFuelIsEmpty;

    [SerializeField]
    private bool shiftPushed;

    private float verticalSpeed;

    [SerializeField]
    private float steamFuel;
    [SerializeField]
    public float steamFallGravityForce;
    [SerializeField]
    private float maxFuelCharge;
    [SerializeField]
    private float basicFuelChargeSpeed;
    [SerializeField]
    private float steamJumpFuelChargeSpeed;
    [SerializeField]
    private float consomationSpeed;

    private void Start()
    {
        playerMoves = GetComponent<ELC_PlayerMoves>();
        animator = gameObject.GetComponent<Animator>();
        steamFuel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //prends les valeurs du script PlayerMoves
        playerIsFalling = playerMoves.playerIsFalling;
        playerIsOnGround = playerMoves.playerIsOnGround;
        verticalSpeed = playerMoves.verticalSpeed;
        isChargingSteamJump = playerMoves.steamJumpIsCharging;


        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("SteamFall") > 0) && playerIsFalling == true && steamFuelIsEmpty == false)
        {
            steamFallEnable = true;
            animator.SetBool("SteamFallEnable", true);
            if(Input.GetKey(KeyCode.LeftShift))
            {
                shiftPushed = true;
            }
            
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            shiftPushed = false;
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetAxis("SteamFall") == 0 && shiftPushed == false)) || playerIsOnGround == true || steamFuelIsEmpty == true)
        {
            steamFallEnable = false;
            animator.SetBool("SteamFallEnable", false);
        }
        
        //Jauge de charge de steam
        if (steamFuel < maxFuelCharge / 2 && playerIsFalling == false && steamFallEnable == false)
        {
            steamFuel = steamFuel + basicFuelChargeSpeed;
        }
        else if(steamFuel < maxFuelCharge && isChargingSteamJump == true)
        {
            steamFuel = steamFuel + steamJumpFuelChargeSpeed;
        }

        if(steamFuel <= 0)
        {
            steamFuelIsEmpty = true;
        }
        else
        {
            steamFuelIsEmpty = false;
        }

        if(steamFallEnable == true)
        {
            steamFuel = steamFuel - consomationSpeed;
        }

        //Faire la jauge d'utilisation
    }
}
