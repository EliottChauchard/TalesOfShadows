using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNF_AppearOnTrigger : MonoBehaviour
{
    public GameObject toHide;
    public KNF_ParallaxLayer pL;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pL.startCameraPos = cameraTransform.position;
        //toHide.GetComponent<KNF_ParallaxLayer>().enabled = true;
    }
}
