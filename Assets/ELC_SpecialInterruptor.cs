using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SpecialInterruptor : MonoBehaviour
{
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private GameObject manor;
    [SerializeField]
    private GameObject manorDoor;

    public bool isActivated;


    // Update is called once per frame
    void Update()
    {
        if(isActivated)
        {
            manor.GetComponent<SpriteRenderer>().sprite = newSprite;
            manorDoor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
