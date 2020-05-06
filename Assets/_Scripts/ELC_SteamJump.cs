using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SteamJump : MonoBehaviour
{
    ELC_PlayerMoves playerMovesScript;
    ELC_LoadingSteamJump loadSteamJump;

    [SerializeField]
    private float jumpForcePlayer;
    [SerializeField]
    private bool playerIsFalling;
    [SerializeField]
    private bool playerIsJumping;
    [SerializeField]
    private bool isOnGround;
    [SerializeField]
    private bool isFullCharged;
    private bool steamJumpPhase;

    public bool isChargingSteamJump;
    public bool isSteamJumping;
    public bool canMove = true;

    [SerializeField]
    public float charge = 0f;
    [SerializeField]
    private float chargeSpeed;
    [SerializeField]
    private float maxCharge;
    private float gravityForce;
    [SerializeField]
    private float testValues;

    private Vector3 LoadingBar;
    private Vector2 jumpForce;
    private Vector2 movesPlayer;
    public Vector2 steamJumpImpulse;

    void Start()
    {
        playerMovesScript = GetComponent<ELC_PlayerMoves>();
        loadSteamJump = GetComponent<ELC_LoadingSteamJump>();

        LoadingBar = GameObject.Find("LoadingSteamJump").transform.localScale;
    }




    void Update()
    {

        playerIsFalling = playerMovesScript.playerIsFalling;
        playerIsJumping = playerMovesScript.playerIsJumping;
        movesPlayer = playerMovesScript.playerMoves;
        isOnGround = playerMovesScript.playerIsOnGround;
        jumpForce = loadSteamJump.jumpDirection;
        gravityForce = playerMovesScript.gravityForceJump;
        steamJumpPhase = playerMovesScript.steamJumpPhase;
        

        steamJumpImpulse = jumpForce * charge;

        testValues = jumpForce.x * charge * 5;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            StartCoroutine("SteamJumpCharge");
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)) && isChargingSteamJump == true && isFullCharged == false)
        {
            SteamJump();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            canMove = true;
            StartCoroutine("Transition");
        }

        if(steamJumpPhase == false)
        {
            charge = 0f;
            isFullCharged = false;
        }

        if(playerIsJumping == true)
        {
            isFullCharged = false;
        }
        if ((playerIsFalling == true || isOnGround == true) && isChargingSteamJump == false)
        {
            isSteamJumping = false;
        }


        LoadingBar = new Vector3(2f, 0.1f, 1f);

    }

    IEnumerator SteamJumpCharge()
    {
        yield return new WaitForSeconds(0.5f);

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
        {
            isChargingSteamJump = true;
            canMove = false;
        }
    }
    IEnumerator Transition()
    {
        isSteamJumping = true;
        yield return new WaitForSeconds(0.5f);
        isChargingSteamJump = false;
    }

    void SteamJump()
    {
        charge = charge + chargeSpeed * Time.deltaTime;
        
        if (charge >= maxCharge)
        {
            isFullCharged = true;
        }
    }
}
