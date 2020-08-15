using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlayerMoves : MonoBehaviour
{
    ELC_SteamJump SteamJumpScript;

    private float horizontalInput;
    public float horizontalSpeed;
    public float verticalSpeed;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Animator animator;
    ELC_SteamFall SteamFallScript;
    
    [SerializeField]
    public int turnPlayerFace;
    [SerializeField]
    private bool playerGoLeft;
    [SerializeField]
    private bool playerGoRight;
    [SerializeField]
    private bool playerImmobile;
    //[SerializeField]
    //private bool playerFaceLeft;
    //[SerializeField]
    //private bool playerFaceRight;
    [SerializeField]
    public bool playerIsOnGround;
    [SerializeField]
    public bool playerIsInGround;
    [SerializeField]
    private bool isTouchingTop;
    [SerializeField]
    private bool isTouchingFace;
    [SerializeField]
    public bool playerIsJumping;
    [SerializeField]
    public bool playerIsFalling = true;
    [SerializeField]
    private bool steamFallEnable;
    [SerializeField]
    private bool playerIsSteamJumping;
    [SerializeField]
    public bool steamJumpIsCharging;
    [SerializeField]
    public bool steamJumpPhase;
    [SerializeField]
    public bool playerCanMove = true;
    [SerializeField]
    private bool canJump;
    [SerializeField]
    private bool canSteamJump;

    //booléens pour les sons
    private bool isPlayingWalk;
    private bool isplayingSteamFall;


    [SerializeField]
    private float steamJumpForceMultiplier;
    [SerializeField]
    private float minimalSteamJumpForce;
    [SerializeField]
    private float ghostJumpDelay;
    [SerializeField]
    private float speed = 1.26f;
    [SerializeField]
    public float jumpForce = 18f;
    [SerializeField]
    private float steamJumpCharge;
    [SerializeField]
    public float gravityForceJump = 0.2f;
    [SerializeField]
    private float gravityForceFall = 0.05f;
    [SerializeField]
    private float steamGravityForceFall;
    //[SerializeField]
    //private float limitAngleSteamJumpY;
    [SerializeField]
    private LayerMask collisionMask;

    //Raycasts player
    RaycastHit2D underPlayerHit;
    RaycastHit2D roofPlayerHit;
    RaycastHit2D facePlayerHit;
    RaycastHit2D uponTheGroundHit;  //Détecteur pour voir si le joueur est dans le sol
    
    [SerializeField]
    private float UponTheGroundRayPositionY = 0.02f;
    [SerializeField]
    private float underRayLenght = 0.14f;
    [SerializeField]
    private float underRayPositionY = 0.16f;
    [SerializeField]
    private float underRayPositionX = 0.07f;
    [SerializeField]
    private float topRayLenght = 0.2f;
    [SerializeField]
    private float topRayPositionY = 0.16f;
    [SerializeField]
    private float topRayPositionX = 0.1f;
    [SerializeField]
    private float faceRayLenght = 0.23f;
    [SerializeField]
    private float faceRayPositionX = 0.1f;
    [SerializeField]
    private float faceRayPositionY = 0.12f;

    private Vector3 startPositionRaycastUnder;
    private Vector3 startPositionRaycastUponTheGround;
    private Vector3 startPositionRaycastTop;
    private Vector3 startPositionRaycastFace;
    

    //Moves
    [SerializeField]
    public Vector3 playerMoves;
    //private Vector2 steamJumpVector;


    private void Start()
    {
        SteamFallScript = GetComponent<ELC_SteamFall>();
        SteamJumpScript = GetComponent<ELC_SteamJump>();
    }

    // Update is called once per frame
    void Update()
    {
        steamFallEnable = SteamFallScript.steamFallEnable;
        playerIsSteamJumping = SteamJumpScript.isSteamJumping;
        steamJumpCharge = SteamJumpScript.charge;
        steamJumpIsCharging = SteamJumpScript.isChargingSteamJump;
        steamGravityForceFall = SteamFallScript.steamFallGravityForce;
        //steamJumpVector = SteamJumpScript.steamJumpImpulse;
        //playerCanMove = SteamJumpScript.canMove;
        //limitAngleSteamJumpY = loadSteamJumpScript.limitY;

        //statut pour dire que le joueur est en phase de SteamJump
        if (playerIsSteamJumping == true || steamJumpIsCharging == true)
        {
            steamJumpPhase = true;
        }
        else
        {
            steamJumpPhase = false;
        }

        //mouvements horizontaux
        if ((playerIsJumping == true || playerIsOnGround == true || steamFallEnable == true || playerIsFalling == true))
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if(steamJumpPhase == true)
            {
                horizontalSpeed = /*steamJumpVector.x*/ horizontalInput * 2;
            }
            else if (steamJumpIsCharging == false && steamJumpPhase == false)
            {
                horizontalSpeed = horizontalInput * speed;
            }
        }

        if(playerCanMove == false) //si le joueur charge son steamJump il ne peut plus bouger
        {
            horizontalSpeed = 0f;
        }

        

        if(FindObjectOfType<ELC_PauseMenu>().isPaused == false)
        {
            if ((playerGoLeft || playerGoRight) && playerIsOnGround && isPlayingWalk == false && steamJumpIsCharging == false)
            {
                FindObjectOfType<ELC_AudioManager>().Play("Walk", true);
                isPlayingWalk = true;
            }
            else if ((playerGoLeft == false && playerGoRight == false) || playerIsOnGround == false)
            {
                FindObjectOfType<ELC_AudioManager>().Stop("Walk");
                isPlayingWalk = false;
            }

            if (horizontalInput < 0 && FindObjectOfType<ELC_SteamPush>().SteamPush == false)
            {
                playerGoLeft = true;
                //playerFaceLeft = true;
                playerGoRight = false;
                //playerFaceRight = false;
                playerImmobile = false;
                spriteRenderer.flipX = true;
                animator.SetBool("IsWalking", true);

            }
            else if (horizontalInput == 0 && FindObjectOfType<ELC_SteamPush>().SteamPush == false)
            {
                playerImmobile = true;
                playerGoRight = false;
                playerGoLeft = false;
                animator.SetBool("IsWalking", false);
            }
            else if (horizontalInput > 0 && FindObjectOfType<ELC_SteamPush>().SteamPush == false)
            {
                playerGoRight = true;
                //playerFaceRight = true;
                playerGoLeft = false;
                //playerFaceLeft = false;
                playerImmobile = false;
                spriteRenderer.flipX = false;
                animator.SetBool("IsWalking", true);
            }
        }
        

        //Si le joueur est au sol
        GroundDetector();
        if (playerIsOnGround)
        {
            verticalSpeed = 0;
            playerIsFalling = false;
        }

        if(playerIsInGround)
        {
            transform.localPosition = transform.localPosition + (new Vector3(0f, 0.02f, 0f));
        }


        //Si le joueur se prend une plateforme sur la tête
        RoofDetector();
        if (isTouchingTop == true && playerIsOnGround == false)
        {
            verticalSpeed = -0.5f;
        }

        //Si le joueur a un mur face à lui
        FaceDetector();
        if (isTouchingFace == true)
        {
            if (playerGoRight == true)
            {
                horizontalSpeed = 0;
            }
            else if (playerGoLeft == true)
            {
                horizontalSpeed = 0;
            }
        }

        //faire en sorte que le joueur se tourne
        if (playerGoLeft == true && FindObjectOfType<ELC_SteamPush>().SteamPush == false)
        {
            turnPlayerFace = -1;
        }
        else if (playerGoRight == true && FindObjectOfType<ELC_SteamPush>().SteamPush == false)
        {
            turnPlayerFace = 1;
        }



        //saut
        if ((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyUp(KeyCode.Space) || (Input.GetAxis("SteamJump") <= 0 && steamJumpPhase == true && Input.GetKey(KeyCode.Space) == false)) && canSteamJump == true  && (playerIsOnGround == true || canJump == true))
        {
            playerIsJumping = true;
            
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsWalking", false);
            //verticalSpeed = jumpForce + steamJumpCharge;
            if (steamJumpPhase == false)
            {
                verticalSpeed = jumpForce;
                FindObjectOfType<ELC_AudioManager>().Play("Jump", false);
            }
            else
            {
                //if (steamJumpVector.y <= 0)
                //{
                    verticalSpeed = 1f * steamJumpCharge * steamJumpForceMultiplier;
                    animator.SetBool("JumpIsCharging", false);

                //}
                //else
                //{
                //    verticalSpeed = steamJumpVector.y * steamJumpCharge * steamJumpForceMultiplier;
                //    animator.SetBool("JumpIsCharging", false);

                //}
                canSteamJump = false;
            }
        }
        else
        {
            animator.SetBool("IsJumping", false);
            if (steamJumpPhase == false)
            {
                canSteamJump = true;
            }
        }

        if (/*playerIsJumping == true  &&*/ verticalSpeed < 0)
        {
            playerIsFalling = true;
            playerIsJumping = false;
        }

        
        
        


        //gravité
        if (playerIsOnGround == false)
        {

            if (playerIsFalling == true && steamFallEnable == false)
            {
                verticalSpeed = verticalSpeed - gravityForceFall * Time.deltaTime;
            }
            else if (playerIsJumping == true)
            {
                verticalSpeed = verticalSpeed - gravityForceJump * Time.deltaTime;
            }
            else if (steamFallEnable == false)
            {
                verticalSpeed = verticalSpeed - gravityForceFall * Time.deltaTime;
            }
            else if (steamFallEnable == true)
            {
                verticalSpeed = 0 - steamGravityForceFall * Time.deltaTime;

                if(isplayingSteamFall == false)
                {
                    FindObjectOfType<ELC_AudioManager>().Play("SteamFall", true);
                    isplayingSteamFall = true;
                }
                
            }
            
        }
        if (steamFallEnable == false)
        {
            FindObjectOfType<ELC_AudioManager>().Stop("SteamFall");
            isplayingSteamFall = false;
        }


        //actualisation des mouvements en tps réel
        playerMoves = new Vector2(horizontalSpeed, verticalSpeed) * Time.deltaTime;

        transform.Translate(playerMoves);
    }



    void GroundDetector()
    {
        startPositionRaycastUnder = new Vector3(transform.position.x - underRayPositionX, transform.position.y - underRayPositionY, transform.position.z);
        startPositionRaycastUponTheGround = new Vector3(startPositionRaycastUnder.x, startPositionRaycastUnder.y + UponTheGroundRayPositionY, startPositionRaycastUnder.z);

        underPlayerHit = Physics2D.Raycast(startPositionRaycastUnder, transform.TransformDirection(new Vector2(1f, 0f)), underRayLenght, collisionMask);
        uponTheGroundHit = Physics2D.Raycast(startPositionRaycastUponTheGround, transform.TransformDirection(new Vector2(1f, 0f)), underRayLenght, collisionMask); //Détecteur pour voir si le joueur est dans le sol

        Debug.DrawRay(startPositionRaycastUnder, transform.TransformDirection(new Vector2(underRayLenght, 0)), Color.green); //pour afficher le rayon de détection
        Debug.DrawRay(startPositionRaycastUponTheGround, transform.TransformDirection(new Vector2(underRayLenght, 0)), Color.green);

        if (underPlayerHit.collider != null)
        {
            playerIsOnGround = true;
            canJump = true;
            animator.SetBool("IsColliding", true);
            if(underPlayerHit.collider.CompareTag("MovingPlateform"))
            {
                this.transform.SetParent(underPlayerHit.collider.transform);
            }
            else
            {
                this.transform.SetParent(null);
            }
        }
        else if(playerIsOnGround == true)
        {
            StartCoroutine("GhostJump");
            playerIsOnGround = false;
            animator.SetBool("IsColliding", false);
        }

        if (uponTheGroundHit.collider != null)
        {
            playerIsInGround = true;
        }
        else
        {
            playerIsInGround = false;
        }

    }

    void RoofDetector()
    {
        startPositionRaycastTop = new Vector3(transform.position.x - topRayPositionX, transform.position.y + topRayPositionY, transform.position.z);

        roofPlayerHit = Physics2D.Raycast(startPositionRaycastTop, transform.TransformDirection(new Vector2(1f, 0f)), topRayLenght, collisionMask);
        
        Debug.DrawRay(startPositionRaycastTop, transform.TransformDirection(new Vector2(topRayLenght, 0f)), Color.yellow);          //fait apparaître le raycast du haut

        if (roofPlayerHit.collider != null)
        {
            isTouchingTop = true;
        }
        else
        {
            isTouchingTop = false;
        }
    }

    void FaceDetector()
    {
        startPositionRaycastFace = new Vector3(transform.position.x + faceRayPositionX * turnPlayerFace, transform.position.y - faceRayPositionY, transform.position.z);
       
        facePlayerHit = Physics2D.Raycast(startPositionRaycastFace, transform.TransformDirection(new Vector2(0f, 1f)), faceRayLenght, collisionMask); //rayon face vertical

        Debug.DrawRay(startPositionRaycastFace, transform.TransformDirection(new Vector2(0f, faceRayLenght)), Color.red);
        if (facePlayerHit.collider != null)
        {
            isTouchingFace = true;
        }
        else
        {
            isTouchingFace = false;
        }
    }
    
    IEnumerator GhostJump()
    {
        if(playerIsJumping == false)
        {
            Debug.Log("ghostJump start");
            yield return new WaitForSeconds(ghostJumpDelay);
            Debug.Log("GhostJump Finish");
            canJump = false;
        }
        else
        {
            canJump = false;
        }
    }
}
