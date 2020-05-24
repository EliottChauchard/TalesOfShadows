using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Collectibles : MonoBehaviour
{

    CircleCollider2D Collider;

    public int numberOfKeys;
    public string tagOfTheObject;
    private float totalKeysCollected;


    [SerializeField]
    private GameObject gameObjectTouched;


    // Update is called once per frame
    void Update()
    {
        totalKeysCollected = PlayerPrefs.GetFloat("TotalKeysCollected");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tagOfTheObject = collision.tag;

        if(tagOfTheObject == "Key")
        {
            numberOfKeys += 1;
            GlobalScoreValues.keysCollected += 1;
            PlayerPrefs.SetFloat("TotalKeysCollected", totalKeysCollected + 1);
            gameObjectTouched = collision.gameObject;
            Destroy(gameObjectTouched);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tagOfTheObject = "Nothing";
    }
}
