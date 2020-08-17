using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_MediumMonster : MonoBehaviour
{
    private ELC_TriggerMonster triggerMonsterScript;
    private GameObject playerObject;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject monsterNest;

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
    private bool isFollowingPlayer;
    [SerializeField]
    private bool isReturningToNest;
    [SerializeField]
    private bool isPatrolling;

    [SerializeField]
    private Vector2 nestDistance;
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
        triggerMonsterScript = this.gameObject.GetComponentInChildren<ELC_TriggerMonster>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        faceDetector();

        playerIsInTheRadius = triggerMonsterScript.playerIsInside;

        nestDistance = new Vector2(monsterNest.transform.localPosition.x - this.transform.localPosition.x, monsterNest.transform.localPosition.y - this.transform.localPosition.y);

        if (playerIsInTheRadius == true)
        {
            StopCoroutine("ReturnToTheNest");
            isFollowingPlayer = true;
            playerObject = triggerMonsterScript.playerGameObject;
            playerDistance = playerObject.transform.position.x - this.transform.position.x;

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
        else if (playerIsInTheRadius == false && isFollowingPlayer == true)
        {
            isFollowingPlayer = false;
            StartCoroutine("ReturnToTheNest");
        }
        else if(isPatrolling == true && isFollowingPlayer == false)
        {
            horizontalSpeed = 0;
        }

        


        if(horizontalSpeed < 0)
        {
            monsterGoLeft = true;
            monsterGoRight = false;
            monsterDontMove = false;
            spriteRenderer.flipX = false;
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
            spriteRenderer.flipX = true;
        }

        monsterMoves = new Vector2(horizontalSpeed, 0f) * Time.deltaTime;
        transform.Translate(monsterMoves);
    }

    void faceDetector()
    {
        raycastStartPosition = new Vector3(transform.position.x + faceRayPositionX * turnMonster, transform.position.y + faceRayPositionY, 0f);
        faceMonsterHit = Physics2D.Raycast(raycastStartPosition, new Vector2(0f, 1f), faceRayLenght, collisionMask);
        Debug.DrawRay(raycastStartPosition, new Vector2(0f, faceRayLenght), Color.green);

        if(faceMonsterHit.collider != null)
        {
            if(faceMonsterHit.collider.CompareTag("Spikes") || faceMonsterHit.collider.CompareTag("Contamination"))
            {
                GlobalScoreValues.mediumEnemyKilled += 1;
                Destroy(this.gameObject);
            }
            else if(faceMonsterHit.collider.CompareTag("MonsterNest") && isFollowingPlayer == false)
            {
                isPatrolling = true;
            }
            else
            {
                wallDetected = true;
            }
        }
        else
        {
            wallDetected = false;
            isPatrolling = false;
        }
    }

    IEnumerator ReturnToTheNest()
    {
        yield return new WaitForSeconds(1f);
        horizontalSpeed = 0f;
        yield return new WaitForSeconds(2f);
        if (nestDistance.x < 0)
        {
            horizontalSpeed = patrolSpeed * (-1);
        }
        else if (nestDistance.x > 0)
        {
            horizontalSpeed = patrolSpeed * 1;
        }

    }
}
