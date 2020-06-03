using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNF_AppearOnTrigger : MonoBehaviour
{
    public KNF_ParallaxLayer pL;
    public KNF_ParallaxLayer pL2;
    public KNF_ParallaxLayer pL3;
    public KNF_ParallaxLayer pL4;
    public KNF_ParallaxLayer pL5;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cameraTransform = Camera.main.transform;
        pL.startCameraPos = cameraTransform.position;
        pL2.startCameraPos = cameraTransform.position;
        pL3.startCameraPos = cameraTransform.position;
        pL4.startCameraPos = cameraTransform.position;
        pL5.startCameraPos = cameraTransform.position;
    }
}
