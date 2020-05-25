using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_MorceauJournal : MonoBehaviour
{
    [SerializeField]
    private Sprite imageMorceauJournal;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private int journalNumber;

    private int inventoryCheck;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inventoryCheck = PlayerPrefs.GetInt("Collectible" + journalNumber);
        if(inventoryCheck == 1)
        {
            spriteRenderer.sprite = imageMorceauJournal;
        }
    }
}
