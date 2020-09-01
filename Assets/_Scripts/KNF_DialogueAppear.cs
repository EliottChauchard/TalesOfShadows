using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNF_DialogueAppear : MonoBehaviour
{
    public GameObject dialogueLines;


    // Start is called before the first frame update
    void Start()
    {
        dialogueLines.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueLines.SetActive(true);
            Debug.Log("yes");
        } 
    }
}
