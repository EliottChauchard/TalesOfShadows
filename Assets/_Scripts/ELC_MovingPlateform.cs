using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_MovingPlateform : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPoint;
    [SerializeField]
    private GameObject startingPoint;

    private Vector2 targetPosition;
    private Vector2 startingPosition;
    [SerializeField]
    public Vector2 movingDirection;

    [SerializeField]
    private bool resetStartingPointAtStart = true;
    public bool isAtStartPoint;
    [SerializeField]
    public bool isReturningToStartPosition;
    [SerializeField]
    public bool activatePlateform;

    [SerializeField]
    private float speed;


    void Start()
    {
        speed = speed * 40f;
        if (resetStartingPointAtStart)
        {
            startingPosition = this.gameObject.transform.localPosition;
            startingPoint.transform.localPosition = startingPosition;
            
        }
        else
        {
            startingPosition = startingPoint.GetComponent<Transform>().localPosition;
        }

        targetPosition = targetPoint.transform.localPosition;
        movingDirection = Vector2.ClampMagnitude(targetPosition - startingPosition, speed);

    }


    void Update()
    {
        if(activatePlateform == true)
        {
            transform.Translate(movingDirection * Time.deltaTime);
        }
    }

    public void startMoving()
    {
        activatePlateform = true;
    }

    void stopMoving()
    {
        activatePlateform = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Plateform touch the target point");
        if (collision.gameObject == targetPoint)
        {
            movingDirection = Vector2.ClampMagnitude(startingPosition - targetPosition, speed);
        }
        else if(collision.gameObject == startingPoint)
        {
            movingDirection = Vector2.ClampMagnitude(targetPosition - startingPosition, speed);
            if (isReturningToStartPosition == true)
            {
                isAtStartPoint = true;
                stopMoving();
                isReturningToStartPosition = false;
            }
        }
    }

    public void Return()
    {
        movingDirection = Vector2.ClampMagnitude(startingPosition - targetPosition, speed);
        isReturningToStartPosition = true;
    }

    public void GoToPoint()
    {
        movingDirection = Vector2.ClampMagnitude(targetPosition - startingPosition, speed);
        isAtStartPoint = false;
    }
}
