using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_ScreenShake : MonoBehaviour
{
    private CinemachineCameraOffset cameraCinemachineTransform;

    [SerializeField]
    private float duration;
    [SerializeField]
    private float durationDecreaseSpeed;
    [SerializeField]
    private float variationScale;
    [SerializeField]
    private float timeRemaining;
    [SerializeField]
    private Vector3 initialPosition;

    [SerializeField]
    public bool launchScreenShake;
    [SerializeField]
    public bool isScreenShaking;

    private float variationValueX;
    private float variationValueY;

    // Start is called before the first frame update
    void Start()
    {
        cameraCinemachineTransform = GetComponent<CinemachineCameraOffset>();
        initialPosition = cameraCinemachineTransform.m_Offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(launchScreenShake == true)
        {
            timeRemaining = duration;
            
            isScreenShaking = true;
            launchScreenShake = false;
        }

        if (timeRemaining > 0)
        {
            variationValueX = Random.Range(-variationScale, variationScale);
            variationValueY = Random.Range(-variationScale, variationScale);

            cameraCinemachineTransform.m_Offset = new Vector3 (initialPosition.x + variationValueX, initialPosition.y + variationValueY, - 400) ;

            timeRemaining = timeRemaining - durationDecreaseSpeed * Time.deltaTime;
        }
        else if(timeRemaining <= 0 && isScreenShaking == true)
        {
            timeRemaining = 0f;
            cameraCinemachineTransform.m_Offset = initialPosition;
            isScreenShaking = false;
        }
    }

    public void ScreenShake(float time, float scale)
    {
        duration = time;
        variationScale = scale;
        launchScreenShake = true;
    }
}
