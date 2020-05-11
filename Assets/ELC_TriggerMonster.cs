using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_TriggerMonster : MonoBehaviour
{
    private ELC_MediumMonster MediumMonsterScript;
    public GameObject playerGameObject;

    private bool playerIsInside;

    // Start is called before the first frame update
    void Start()
    {
        MediumMonsterScript = gameObject.GetComponentInParent<ELC_MediumMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        MediumMonsterScript.playerIsInTheRadius = playerIsInside;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsInside = true;
            playerGameObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIsInside = false;
        }
    }
}
