using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_MediumMonster : MonoBehaviour
{
    private ELC_TriggerMonster triggerMonsterScript;
    private GameObject playerObject;

    private RaycastHit2D faceMonsterHit;
    [SerializeField]
    private LayerMask collisionMask;


    public bool playerIsInTheRadius;

    private Vector2 monsterMoves;
    private Vector3 raycastStartPosition;

    [SerializeField]
    private bool wallDetected;
    private bool monsterGoLeft;
    private bool monsterGoRight;
    private bool monsterDontMove;

    [SerializeField]
    private float turnMonster = 1;
    [SerializeField]
    private float patrolSpeed;
    [SerializeField]
    private float followSpeed;
    [SerializeField]
    private float playerDistance;
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float faceRayPositionX;
    [SerializeField]
    private float faceRayPositionY;
    [SerializeField]
    private float faceRayLenght;

    private void Start()
    {
        triggerMonsterScript = gameObject.GetComponentInChildren<ELC_TriggerMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        faceDetector();

        if (playerIsInTheRadius == true)
        {
            playerObject = triggerMonsterScript.playerGameObject;
            playerDistance = playerObject.transform.localPosition.x - this.transform.localPosition.x;

            if(playerDistance < 0)
            {
                turnMonster = -1;
            }
            else if(playerDistance == 0 || wallDetected == true)
            {
                turnMonster = 0;
            }
            else if(playerDistance > 0)
            {
                turnMonster = 1;
            }
            horizontalSpeed = followSpeed * turnMonster;
        }
        else
        {
            if(monsterGoLeft == true && wallDetected == true)
            {
                turnMonster = 1;
            }
            else if(monsterGoRight == true && wallDetected == true)
            {
                turnMonster = -1;
            }
            horizontalSpeed = patrolSpeed * turnMonster;
        }

        if(horizontalSpeed < 0)
        {
            monsterGoLeft = true;
            monsterGoRight = false;
            monsterDontMove = false;
        }
        else if (horizontalSpeed == 0f)
        {
            monsterGoLeft = false;
            monsterGoRight = false;
            monsterDontMove = true;
        }
        else if (horizontalSpeed > 0)
        {
            monsterGoLeft = false;
            monsterGoRight = true;
            monsterDontMove = false;
        }

        monsterMoves = new Vector2(horizontalSpeed, 0f) * Time.deltaTime;
        transform.Translate(monsterMoves);
    }

    void faceDetector()
    {
        raycastStartPosition = new Vector3(transform.localPosition.x + faceRayPositionX * turnMonster, transform.localPosition.y + faceRayPositionY, 0f);
        faceMonsterHit = Physics2D.Raycast(raycastStartPosition, new Vector2(0f, 1f), faceRayLenght, collisionMask);
        Debug.DrawRay(raycastStartPosition, new Vector2(0f, faceRayLenght), Color.green);

        if(faceMonsterHit.collider != null)
        {
            if(faceMonsterHit.collider.CompareTag("Spikes") || faceMonsterHit.collider.CompareTag("Contamination"))
            {
                GlobalScoreValues.mediumEnemyKilled += 1;
                Destroy(this.gameObject);
            }
            else
            {
                wallDetected = true;
            }
        }
        else
        {
            wallDetected = false;
        }
    }
}
