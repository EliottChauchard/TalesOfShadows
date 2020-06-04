using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Collectibles : MonoBehaviour
{
    [SerializeField]
    private GameObject firstKey;
    [SerializeField]
    private GameObject secondKey;
    [SerializeField]
    private GameObject thirdKey;

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

        if(numberOfKeys == 3)
        {
            thirdKey.SetActive(true);
        }
        else if(numberOfKeys >= 2)
        {
            secondKey.SetActive(true);
            thirdKey.SetActive(false);
        }
        else if(numberOfKeys >= 1)
        {
            firstKey.SetActive(true);
            secondKey.SetActive(false);
            thirdKey.SetActive(false);
        }
        else if(numberOfKeys == 0)
        {
            firstKey.SetActive(false);
            secondKey.SetActive(false);
            thirdKey.SetActive(false);
        }

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
            if(PlayerPrefs.GetInt("Collectible" + journalNumber) == 0)
            {
                PlayerPrefs.SetInt("NumberOfCollectibles", (totalJournaux + 1));
            }
            FindObjectOfType<ELC_AudioManager>().Play("Journal", false);
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
