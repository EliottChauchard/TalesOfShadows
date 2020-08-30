using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_ActivationTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject GameObject;
    [SerializeField]
    private float activationDuration;
    [SerializeField]
    private float desactivationDuration;

    [SerializeField]
    private bool finishOneTurn = true;
    
    void Update()
    {
        if(finishOneTurn == true)
        {
            StartCoroutine("Clock");
        }
    }

    IEnumerator Clock()
    {
        finishOneTurn = false;
        GameObject.SetActive(false);
        yield return new WaitForSeconds(desactivationDuration);
        GameObject.SetActive(true);
        yield return new WaitForSeconds(activationDuration);
        finishOneTurn = true;
    }
}
