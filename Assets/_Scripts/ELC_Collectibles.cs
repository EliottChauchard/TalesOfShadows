using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Collectibles : MonoBehaviour
{

    CircleCollider2D Collider;

    public float numberOfSpecialKeys;
    public int numberOfKeys;
    public string tagOfTheObject;
    private float totalKeysCollected;
    private int totalJournaux;

    private int journalNumber;

    [SerializeField]
    private GameObject gameObjectTouched;


    // Update is called once per frame
    void Update()
    {
        totalKeysCollected = PlayerPrefs.GetFloat("TotalKeysCollected");
        totalJournaux = PlayerPrefs.GetInt("NumberOfCollectibles");
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
            FindObjectOfType<ELC_AudioManager>().Play("Collectibles", false);
            Destroy(gameObjectTouched);
        }
        else if(tagOfTheObject == "Journal")
        {
            journalNumber = collision.GetComponent<ELC_Journal>().refNumber;
            PlayerPrefs.SetInt("Collectible" + journalNumber, 1);
            PlayerPrefs.SetInt("NumberOfCollectibles", (totalJournaux + 1));
            FindObjectOfType<ELC_AudioManager>().Play("Collectibles", false);
        }
        else if (tagOfTheObject == "SpecialKey")
        {
            numberOfSpecialKeys += 1f;
            gameObjectTouched = collision.gameObject;
            FindObjectOfType<ELC_AudioManager>().Play("Collectibles", false);
            Destroy(gameObjectTouched);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tagOfTheObject = "Nothing";
    }
}
