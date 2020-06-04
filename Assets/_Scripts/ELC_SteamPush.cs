using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SteamPush : MonoBehaviour
{
    private ELC_IALittleMonster littleMonsterScript;
    ELC_PlayerMoves PlayerMovesScript;
    private Animator animator;
    public bool SteamPush;

    [SerializeField]
    private GameObject steamParticles;

    RaycastHit2D detection1;
    RaycastHit2D detection2;
    RaycastHit2D detection3;
    RaycastHit2D detection4;
    RaycastHit2D detection5;

    [SerializeField]
    private LayerMask collisionMask;
    [SerializeField]
    private bool canSteamPush = true;
    [SerializeField]
    private float reloadTime;

    private bool hasTurnedLeft;
    private bool hasTurnedRight;
    

    [SerializeField]
    private float rayLenght;
    [SerializeField]
    private float ejectForce;
    [SerializeField]
    private float stunDelay;
    [SerializeField]
    private float ejectMonsterForce;


    private int turnFace;


    private Vector3 startPosition;

    void Start()
    {
        PlayerMovesScript = GetComponent<ELC_PlayerMoves>();
        animator = gameObject.GetComponent<Animator>();
        hasTurnedLeft = true;
    }
    
    void Update()
    {
        turnFace = PlayerMovesScript.turnPlayerFace;

        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ZoneAction();

        if((Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Z)) && canSteamPush == true)
        {
            animator.SetBool("SteamPush", true);
            FindObjectOfType<ELC_AudioManager>().Play("SteamPush", false);
            

            StartCoroutine("WaitForPush", 0.05f);

            StartCoroutine("ReloadSteamPush");
            
        }

        if (Input.GetKeyUp(KeyCode.JoystickButton2) || Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("SteamPush", false);
        }

        if(turnFace == -1 && hasTurnedLeft == false)
        {
            steamParticles.GetComponent<Transform>().Rotate(new Vector3(180f, 0f, 0f) );
            hasTurnedLeft = true;
            hasTurnedRight = false;
        }
        else if(turnFace == 1 && hasTurnedRight == false)
        {
            steamParticles.GetComponent<Transform>().Rotate(new Vector3(180f, 0f, 0f));;
            hasTurnedLeft = false;
            hasTurnedRight = true;
        }

    }

    void ZoneAction()
    {
        detection1 = Physics2D.Raycast(startPosition, transform.TransformDirection(new Vector2(1f * turnFace, 0f)), rayLenght, collisionMask);
        Debug.DrawRay(startPosition, transform.TransformDirection(new Vector2(rayLenght * turnFace, 0f)), Color.magenta);

        detection2 = Physics2D.Raycast(startPosition, transform.TransformDirection(new Vector2(1f * turnFace, 0.2f)), rayLenght, collisionMask);
        Debug.DrawRay(startPosition, transform.TransformDirection(new Vector2(rayLenght * turnFace, 0.2f)), Color.magenta);

        detection3 = Physics2D.Raycast(startPosition, transform.TransformDirection(new Vector2(1f * turnFace, 0.4f)), rayLenght, collisionMask);
        Debug.DrawRay(startPosition, transform.TransformDirection(new Vector2(rayLenght * turnFace, 0.4f)), Color.magenta);

        detection4 = Physics2D.Raycast(startPosition, transform.TransformDirection(new Vector2(1f * turnFace, -0.2f)), rayLenght, collisionMask);
        Debug.DrawRay(startPosition, transform.TransformDirection(new Vector2(rayLenght * turnFace, -0.2f)), Color.magenta);

        detection5 = Physics2D.Raycast(startPosition, transform.TransformDirection(new Vector2(1f * turnFace, -0.4f)), rayLenght, collisionMask);
        Debug.DrawRay(startPosition, transform.TransformDirection(new Vector2(rayLenght * turnFace, -0.4f)), Color.magenta);
    }

    IEnumerator StunMonster()
    {
        

        littleMonsterScript.isStun = true;
        yield return new WaitForSeconds(stunDelay);
        littleMonsterScript.isStun = false;
    }

    IEnumerator ReloadSteamPush()
    {
        canSteamPush = false;
        yield return new WaitForSeconds(reloadTime);
        canSteamPush = true;
    }

    IEnumerator WaitForPush(float timeToWait)
    {
        SteamPush = true;
        yield return new WaitForSeconds(timeToWait);

        if (FindObjectOfType<ELC_ScreenShake>().isScreenShaking == false)
        {
            yield return new WaitForSeconds(0.1f);
            FindObjectOfType<ELC_ScreenShake>().ScreenShake(0.4f, 0.04f);
        }
        animator.SetBool("SteamPush", false);

        if (detection1.collider != null)
        {
            if (detection1.collider.CompareTag("Monster"))
            {
                littleMonsterScript = detection1.collider.GetComponent<ELC_IALittleMonster>();
                StartCoroutine("StunMonster");
                detection1.rigidbody.AddForce(new Vector2(ejectMonsterForce * turnFace, 0f));

            }
            else if (detection1.collider.CompareTag("SensibleObject"))
            {
                detection1.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
        }
        else if (detection2.collider != null)
        {
            if (detection2.collider.CompareTag("Monster"))
            {
                littleMonsterScript = detection2.collider.GetComponent<ELC_IALittleMonster>();
                StartCoroutine("StunMonster");
                detection2.rigidbody.AddForce(new Vector2(ejectMonsterForce * turnFace, 0f));
            }
            else if (detection2.collider.CompareTag("SensibleObject"))
            {
                detection2.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
        }
        else if (detection3.collider != null)
        {
            if (detection3.collider.CompareTag("Monster"))
            {
                littleMonsterScript = detection3.collider.GetComponent<ELC_IALittleMonster>();
                StartCoroutine("StunMonster");
                detection3.rigidbody.AddForce(new Vector2(ejectMonsterForce * turnFace, 0f));
            }
            else if (detection3.collider.CompareTag("SensibleObject"))
            {
                detection3.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
        }
        else if (detection4.collider != null)
        {
            if (detection4.collider.CompareTag("Monster"))
            {
                littleMonsterScript = detection4.collider.GetComponent<ELC_IALittleMonster>();
                StartCoroutine("StunMonster");
                detection4.rigidbody.AddForce(new Vector2(ejectMonsterForce * turnFace, 0f));
            }
            else if (detection4.collider.CompareTag("SensibleObject"))
            {
                detection4.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
        }
        else if (detection5.collider != null)
        {

            if (detection5.collider.CompareTag("Monster"))
            {
                littleMonsterScript = detection5.collider.GetComponent<ELC_IALittleMonster>();
                StartCoroutine("StunMonster");
                detection5.rigidbody.AddForce(new Vector2(ejectMonsterForce * turnFace, 0f));
            }
            else if (detection5.collider.CompareTag("SensibleObject"))
            {
                detection5.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
        }
        yield return new WaitForSeconds(1f);
        
        SteamPush = false;
    }
}
