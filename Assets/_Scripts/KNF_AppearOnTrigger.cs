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
    public KNF_ParallaxLayer pL6;
    public KNF_ParallaxLayer pL7;
    private Transform cameraTransform;
    public GameObject destroyIt;

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
        pL6.startCameraPos = cameraTransform.position;
        pL7.startCameraPos = cameraTransform.position;
        destroyIt.SetActive(false);
    }
}
