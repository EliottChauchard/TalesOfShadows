using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNF_ZoomEvent : MonoBehaviour
{
    public Animator animCamera;
    public ELC_Levier levi;
    public ELC_Levier levi2;
    public ELC_Levier levi3;
    private int count = 0;
    public float timeBetween = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")) && count == 0)
        {

            animCamera.SetTrigger("Dezoom");
            count = 1;
            levi.isActivated = true;
            levi2.isActivated = true;
            levi3.isActivated = true;
            StartCoroutine(ZoomEvent());
        }
    }

    IEnumerator ZoomEvent()
    {
        yield return new WaitForSeconds(timeBetween);
        levi.isActivated = false;
        levi2.isActivated = false;
        levi3.isActivated = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")) && count == 1)
        {
            animCamera.SetTrigger("Zoom");
            count = 2;
        }
    }
}

