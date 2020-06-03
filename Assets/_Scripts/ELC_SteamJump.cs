using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SteamJump : MonoBehaviour
{
    ELC_PlayerMoves playerMovesScript;
    ELC_LoadingSteamJump loadSteamJump;

    private Animator animator;

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

    private bool launchLoad;
    private bool endLoad;

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

    private bool isLoading;

    private Vector3 LoadingBar;
    private Vector2 jumpForce;
    private Vector2 movesPlayer;
    public Vector2 steamJumpImpulse;

    void Start()
    {
        playerMovesScript = GetComponent<ELC_PlayerMoves>();
        loadSteamJump = GetComponent<ELC_LoadingSteamJump>();
        animator = GetComponent<Animator>();

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

        if (charge >= maxCharge)
        {
            isFullCharged = true;
        }
        else if (charge < maxCharge)
        {
            isFullCharged = false;
        }


        steamJumpImpulse = jumpForce * charge;

        testValues = jumpForce.x * charge * 5;

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetAxis("SteamJump") > 0 && launchLoad ==true))
        {
            StartCoroutine("SteamJumpCharge");
            launchLoad = false;
            Debug.Log("Launch chargingSJ");
            charge = 0f;
        }

        if ((Input.GetKey(KeyCode.Space) || (Input.GetAxis("SteamJump") > 0 && Input.GetKey(KeyCode.Space) == false)) && isChargingSteamJump == true && isFullCharged == false)
        {
            SteamJump();
            
            if (Input.GetKey(KeyCode.Space) == false)
            {
                endLoad = true;
            }
            
            Debug.Log("chargingSJ");
        }

        if ((Input.GetKeyUp(KeyCode.Space) || (Input.GetAxis("SteamJump") <= 0 && endLoad == true)) && isSteamJumping == false && isChargingSteamJump == true)
        {
            
            canMove = true;
            StartCoroutine("Transition");
            animator.SetBool("JumpIsCharging", false);
            isLoading = false;
            endLoad = false;
            Debug.Log("Launch SteamJump");
            
            FindObjectOfType<ELC_AudioManager>().Play("SteamJump", false);
            
            
            FindObjectOfType<ELC_AudioManager>().Stop("SteamJumpChargeBegin");

        }
        
        if(isChargingSteamJump == true && isSteamJumping == false)
        {
            if (FindObjectOfType<ELC_ScreenShake>().isScreenShaking == false)
            {
                if(charge < maxCharge)
                {
                    FindObjectOfType<ELC_ScreenShake>().ScreenShake(0.02f, 0.001f);
                }
                else
                {
                    FindObjectOfType<ELC_ScreenShake>().ScreenShake(0.02f, 0.010f);
                }
                
            }
        }
        
        if (isOnGround == true && isChargingSteamJump == false)
        {
            isSteamJumping = false;
            charge = 0f;
            launchLoad = true;
        }


        LoadingBar = new Vector3(2f, 0.1f, 1f);

    }

    IEnumerator SteamJumpCharge()
    {
        yield return new WaitForSeconds(0.5f);

        if(Input.GetKey(KeyCode.Space) || (Input.GetAxis("SteamJump") > 0 && Input.GetKey(KeyCode.Space) == false) && isLoading == false)
        {
            FindObjectOfType<ELC_AudioManager>().Play("SteamJumpChargeBegin", false);
            animator.SetBool("JumpIsCharging", true);
            isChargingSteamJump = true;
            canMove = false;
            isLoading = true;
        }
    }
    IEnumerator Transition()
    {
        isSteamJumping = true;
        yield return new WaitForSeconds(0.5f);
        charge = 0f;
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
