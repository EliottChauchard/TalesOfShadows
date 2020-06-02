using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_CheatsCodes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.transform.position = new Vector2(-11.675f, -41.826f);
        }
    }
}
