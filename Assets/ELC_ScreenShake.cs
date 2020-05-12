using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_ScreenShake : MonoBehaviour
{
    private Transform cameraTransform;

    [SerializeField]
    private float duration;
    [SerializeField]
    private float durationDecreaseSpeed;
    [SerializeField]
    private float variationScale;
    [SerializeField]
    private float timeRemaining;
    private Vector3 initialPosition;

    [SerializeField]
    private bool isEnable;

    private float variationValueX;
    private float variationValueY;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        initialPosition = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnable == true)
        {
            timeRemaining = duration;
        }

        if (timeRemaining > 0)
        {
            variationValueX = Random.Range(-variationScale, variationScale);
            variationValueY = Random.Range(-variationScale, variationScale);

            cameraTransform.localPosition = new Vector3 (initialPosition.x + variationValueX, initialPosition.y + variationValueY) ;

            timeRemaining = durationDecreaseSpeed * Time.deltaTime;
        }
        else
        {
            duration = 0f;
            cameraTransform.localPosition = initialPosition;
        }


    }
}
