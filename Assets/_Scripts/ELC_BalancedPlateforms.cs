using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_BalancedPlateforms : MonoBehaviour
{
    [SerializeField]
    private GameObject StartingPoint;
    [SerializeField]
    private GameObject DownPoint;
    [SerializeField]
    private GameObject SecondPlateform;
    private ELC_BalancedPlateforms SecondPlatformScript;

    public bool playerIsOnThePlatform;
    public bool playerIsOnTheOtherPLatform;
    private bool isAtDownPoint;

    [SerializeField]
    private float speed;

    public Vector2 plateformMoves;
    private Vector2 finalPlateformMoves;
    
    void Start()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x, StartingPoint.transform.localPosition.y);
        DownPoint.transform.localPosition = new Vector2(StartingPoint.transform.localPosition.x, DownPoint.transform.localPosition.y);
        SecondPlatformScript = SecondPlateform.GetComponent<ELC_BalancedPlateforms>();
    }
    
    void Update()
    {
        

        if(playerIsOnThePlatform == true)
        {
            SecondPlatformScript.playerIsOnTheOtherPLatform = true;
            SecondPlatformScript.plateformMoves = -plateformMoves;

            if (playerIsOnThePlatform && isAtDownPoint == false)
            {
                plateformMoves = new Vector2(0, DownPoint.transform.localPosition.y - this.transform.localPosition.y);
                SecondPlatformScript.plateformMoves = new Vector2(0, this.transform.localPosition.y - DownPoint.transform.localPosition.y);
            }
        }
        
        else if(playerIsOnThePlatform == false && playerIsOnTheOtherPLatform == false)
        {
            Return();
        }

        

        

        finalPlateformMoves = Vector2.ClampMagnitude(plateformMoves, speed) * Time.deltaTime;
        transform.Translate(finalPlateformMoves);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject == DownPoint)
    //    {
    //        isAtDownPoint = true;
    //    }
        
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject == DownPoint)
    //    {
    //        isAtDownPoint = false;
    //    }
    //}

    private void Return()
    {
        plateformMoves = new Vector2(0, StartingPoint.transform.localPosition.y - this.transform.localPosition.y);
        SecondPlatformScript.playerIsOnTheOtherPLatform = false;
    }
}
