using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_IALittleMonster : MonoBehaviour
{
    [SerializeField]
    private bool monsterCollideWall;
    [SerializeField]
    private bool monsterFaceLeft = true;
    [SerializeField]
    private bool monsterFaceRight;

    private Vector2 littleMonsterMoves;

    [SerializeField]
    private LayerMask collisionMask;

    private RaycastHit2D faceMonsterHit;

    [SerializeField]
    private float Speed;
    private float movesX;
    [SerializeField]
    private float faceRayPositionY = 0.14f;
    [SerializeField]
    private float faceRayPositionX = 0.23f;
    [SerializeField]
    private float faceRayLenght = 0.27f;
    [SerializeField]
    private float turnMonsterFace = -1;

    void Update()
    {
        EnemyFaceDetector();

        if (monsterCollideWall == true && monsterFaceLeft == true)
        {
            turnMonsterFace = 1;
            monsterFaceRight = true;
            monsterFaceLeft = false;
        }

        else if(monsterCollideWall == true && monsterFaceRight == true)
        {
            turnMonsterFace = -1;
            monsterFaceLeft = true;
            monsterFaceRight = false;
        }

        movesX = Speed * turnMonsterFace;

        littleMonsterMoves = new Vector2(movesX, 0f) * Time.deltaTime;
        transform.Translate(littleMonsterMoves);
    }

    void EnemyFaceDetector()
    {
        Vector3 startPositionRaycastFace = new Vector3(transform.position.x + faceRayPositionX * turnMonsterFace, transform.position.y - faceRayPositionY, transform.position.z);

        faceMonsterHit = Physics2D.Raycast(startPositionRaycastFace, transform.TransformDirection(new Vector2(0f, 1f)), faceRayLenght, collisionMask); //rayon face vertical
        Debug.DrawRay(startPositionRaycastFace, transform.TransformDirection(new Vector2(0f, faceRayLenght)), Color.red);

        if (faceMonsterHit.collider != null)
        {
            monsterCollideWall = true;
        }
        else
        {
            monsterCollideWall = false;
        }
    }
}
