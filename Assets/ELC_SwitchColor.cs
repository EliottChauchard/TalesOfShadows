using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SwitchColor : MonoBehaviour
{
    [SerializeField]
    private Material shader;
    

    // Update is called once per frame
    void Update()
    {
        shader.SetColor("Color_39D6A3EA", Color.black);
    }
}
