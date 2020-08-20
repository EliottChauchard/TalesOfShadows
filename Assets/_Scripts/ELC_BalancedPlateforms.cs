using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_BalancedPlateforms : MonoBehaviour
{
    [SerializeField]
    private GameObject StartingPoint;
    [SerializeField]
    private GameObject TopPoint;
    [SerializeField]
    private GameObject DownPoint;
    [SerializeField]
    private GameObject SecondPlateform;

    public bool playerIsOnThePlatform;
    private bool isAtTopPoint;
    private bool isAtDownPoint;

    [SerializeField]
    private float speed;

    private Vector2 plateformMoves;
    
    void Start()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x, StartingPoint.transform.localPosition.y);
        TopPoint.transform.localPosition = new Vector2(StartingPoint.transform.localPosition.x, TopPoint.transform.localPosition.y);
        DownPoint.transform.localPosition = new Vector2(StartingPoint.transform.localPosition.x, StartingPoint.transform.localPosition.y - (TopPoint.transform.localPosition.y - StartingPoint.transform.localPosition.y));
    }
    
    void Update()
    {
        if(playerIsOnThePlatform && isAtDownPoint == false)
        {
            plateformMoves = new Vector2(0, DownPoint.transform.localPosition.y - StartingPoint.transform.localPosition.y);
        }
        else if (playerIsOnThePlatform && isAtDownPoint == true)
        {
            plateformMoves = new Vector2(0, 0);
        }

        if(playerIsOnThePlatform == false)
        {
            plateformMoves = new Vector2(0, StartingPoint.transform.localPosition.y - this.transform.localPosition.y);
        }

        plateformMoves = Vector2.ClampMagnitude(plateformMoves, speed);
        transform.Translate(plateformMoves);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == DownPoint)
        {
            isAtDownPoint = true;
        }
        else if(collision.gameObject == TopPoint)
        {
            isAtTopPoint = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAtDownPoint = false;
        isAtTopPoint = false;
    }
}
