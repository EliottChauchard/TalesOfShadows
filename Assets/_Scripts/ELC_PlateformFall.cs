using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlateformFall : MonoBehaviour
{
    [SerializeField]
    private GameObject plateform;
    private BoxCollider2D plateformCollider;
    private SpriteRenderer plateformSpriteRenderer;
    [SerializeField]
    private float timeBeforeFall;

    // Start is called before the first frame update
    void Start()
    {
        plateformCollider = plateform.GetComponent<BoxCollider2D>();
        plateformSpriteRenderer = plateform.GetComponent<SpriteRenderer>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("PlateformFall");
        }
    }

    IEnumerator PlateformFall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        plateformCollider.enabled = false;
        plateformSpriteRenderer.enabled = false;
    }
}
