using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNF_FallEvent : MonoBehaviour
{
    public Animator crossFade;
    public int count = 0;
    [SerializeField]
    private string animationToPlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")) && count == 0)
        {
            
            crossFade.SetTrigger(animationToPlay);
            count = 1;
        }
    }

}
