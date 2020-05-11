using UnityEngine;

public class KNF_ParallaxLayer : MonoBehaviour
{
    [SerializeField] float multiplier_x = 0.0f;
    [SerializeField] float multiplier_y = 0.0f;
    [SerializeField] bool horizontalOnly = true;

    private Transform cameraTransform;

    private Vector3 startCameraPos;
    private Vector3 startPos;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startCameraPos = cameraTransform.position;
        startPos = transform.position;
    }


    private void LateUpdate()
    {
        var position = startPos;
        if (horizontalOnly)
            position.x += multiplier_x * (cameraTransform.position.x - startCameraPos.x);
        else
            position.x += multiplier_x * (cameraTransform.position.x - startCameraPos.x);
            position.y += multiplier_y * (cameraTransform.position.y - startCameraPos.y);

        transform.position = position;
    }

}
