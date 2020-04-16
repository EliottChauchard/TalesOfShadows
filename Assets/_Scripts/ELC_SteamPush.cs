using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SteamPush : MonoBehaviour
{
    ELC_PlayerMoves PlayerMovesScript;

    RaycastHit2D detection1;
    RaycastHit2D detection2;
    RaycastHit2D detection3;
    RaycastHit2D detection4;
    RaycastHit2D detection5;

    [SerializeField]
    private LayerMask collisionMask;

    [SerializeField]
    private float rayLenght;
    [SerializeField]
    private float ejectForce;


    private int turnFace;


    private Vector3 startPosition;

    void Start()
    {
        PlayerMovesScript = GetComponent<ELC_PlayerMoves>();
    }
    
    void Update()
    {
        turnFace = PlayerMovesScript.turnPlayerFace;

        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ZoneAction();

        if(Input.GetKeyDown(KeyCode.C))
        {
            if (detection1.collider != null && detection1.collider.CompareTag("SensibleObject"))
            {
                detection1.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
            else if (detection2.collider != null && detection2.collider.CompareTag("SensibleObject"))
            {
                detection2.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
            else if (detection3.collider != null && detection3.collider.CompareTag("SensibleObject"))
            {
                detection3.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
            else if (detection4.collider != null && detection4.collider.CompareTag("SensibleObject"))
            {
                detection4.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
            else if (detection5.collider != null && detection5.collider.CompareTag("SensibleObject"))
            {
                detection5.rigidbody.AddForce(new Vector2(ejectForce * turnFace, 0f));
            }
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
}
