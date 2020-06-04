using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Journal : MonoBehaviour
{
    [SerializeField]
    public int refNumber;
    private int numberSaved;
    public GameObject pieceJournal;
    private bool isTaken;
    private bool hasleft;
    public float dissapearTime = 0.2f;

    private void Start()
    {
        pieceJournal.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTaken = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasleft = true;
        }
    }


    void Update()
    {
        numberSaved = PlayerPrefs.GetInt("Collectible" + refNumber);

        if (isTaken == true)
        {
            pieceJournal.SetActive(true);
            StartCoroutine(ShowingPJ());
        }
    }

    IEnumerator ShowingPJ()
    {
        if (hasleft == true)
        {
            yield return new WaitForSeconds(dissapearTime);
            pieceJournal.SetActive(false);
            this.gameObject.SetActive(false);
            yield return null;
        }

    }
}