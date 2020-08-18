using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_IALittleMonster : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private bool monsterCollideWall;
    [SerializeField]
    private bool monsterFaceLeft = true;
    [SerializeField]
    private bool monsterFaceRight;
    [SerializeField]
    public bool isStun;

    private Vector2 littleMonsterMoves;

    [SerializeField]
    private LayerMask collisionMask;

    private RaycastHit2D faceMonsterHit;

    [SerializeField]
    public float speedLittleMonster;
    private float movesX;
    [SerializeField]
    private float faceRayPositionY = 0.14f;
    [SerializeField]
    private float faceRayPositionX = 0.23f;
    [SerializeField]
    private float faceRayLenght = 0.27f;
    [SerializeField]
    private float turnMonsterFace = -1;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        EnemyFaceDetector();

        if (monsterCollideWall == true && monsterFaceLeft == true)
        {
            turnMonsterFace = 1;
            monsterFaceRight = true;
            monsterFaceLeft = false;
            spriteRenderer.flipX = true;
        }

        else if(monsterCollideWall == true && monsterFaceRight == true)
        {
            turnMonsterFace = -1;
            monsterFaceLeft = true;
            monsterFaceRight = false;
            spriteRenderer.flipX = false;
        }


        movesX = speedLittleMonster * turnMonsterFace;

        

        littleMonsterMoves = new Vector2(movesX, 0f) * Time.deltaTime;
        if(isStun == false)
        {
            transform.Translate(littleMonsterMoves);
        }
        
    }

    void EnemyFaceDetector()
    {
        Vector3 startPositionRaycastFace = new Vector3(transform.position.x + faceRayPositionX * turnMonsterFace, transform.position.y - faceRayPositionY, transform.position.z);

        faceMonsterHit = Physics2D.Raycast(startPositionRaycastFace, transform.TransformDirection(new Vector2(0f, 1f)), faceRayLenght, collisionMask); //rayon face vertical
        Debug.DrawRay(startPositionRaycastFace, transform.TransformDirection(new Vector2(0f, faceRayLenght)), Color.red);

        if (faceMonsterHit.collider != null)
        {
            if(faceMonsterHit.collider.tag == "Spikes" || faceMonsterHit.collider.tag == "Contamination")
            {
                GlobalScoreValues.littleEnemyKilled += 1;
                Destroy(this.gameObject);
            }
            else
            {
                monsterCollideWall = true;
            }
        }
        else

        {
            monsterCollideWall = false;
        }
    }
}
