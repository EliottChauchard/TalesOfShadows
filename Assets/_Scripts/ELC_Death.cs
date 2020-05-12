using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Death : MonoBehaviour
{
    private ELC_LastChekpoint LastCheckpointScript;
    private Animator animator;

    public bool isDying;

    [SerializeField]
    private float waitTime;

    private void Start()
    {
        LastCheckpointScript = gameObject.GetComponent<ELC_LastChekpoint>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Contamination")
        {
            Debug.Log("Touche l'ennemi");
            StartCoroutine("Death");
        }
    }

    IEnumerator Death()
    {
        animator.SetBool("IsDying", true);
        isDying = true;
        yield return new WaitForSeconds(waitTime);

        animator.SetBool("IsDying", false);
        isDying = false;
        transform.position = LastCheckpointScript.CheckPointTransform;
    }
}
