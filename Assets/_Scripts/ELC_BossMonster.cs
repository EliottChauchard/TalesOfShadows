using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_BossMonster : MonoBehaviour
{
    private GameObject playerObject;
    private ELC_TriggerMonster triggerMonsterScript;
    [SerializeField]
    private LayerMask collisionMask;

    private bool playerIsNear;

    private bool monsterTouchWall;

    private float turnMonsterFace;
    [SerializeField]
    private float patrolSpeed;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashDelay;
    [SerializeField]
    private Vector2 playerDistance;
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float verticalSpeed;

    private Vector3 monsterMoves;

    private RaycastHit2D bossRaycastHit;
    private Vector3 raycastStartPosition;
    private float rayPositionX;
    private float rayPositionY;
    private float rayLenght;

    private void Start()
    {
        triggerMonsterScript = gameObject.GetComponentInChildren<ELC_TriggerMonster>();
    }


    // Update is called once per frame
    void Update()
    {
        playerIsNear = triggerMonsterScript.playerIsInside;
        playerObject = triggerMonsterScript.playerGameObject;

        faceDetector();

        if(playerIsNear)
        {
            playerDistance = playerObject.transform.localPosition - this.transform.localPosition;
        }

        monsterMoves = new Vector3(horizontalSpeed, verticalSpeed) * Time.deltaTime;
        transform.Translate(monsterMoves);
    }

    void faceDetector()
    {
        raycastStartPosition = new Vector3(transform.localPosition.x + rayPositionX * turnMonsterFace, transform.localPosition.y + rayPositionY, 0f);
        bossRaycastHit = Physics2D.Raycast(raycastStartPosition, new Vector2(0f, 1f), rayLenght, collisionMask);
        Debug.DrawRay(raycastStartPosition, new Vector2(0f, rayLenght), Color.green);

        if (bossRaycastHit.collider != null)
        {
            monsterTouchWall = true;
        }
        else
        {
            monsterTouchWall = false;
        }
    }
}
