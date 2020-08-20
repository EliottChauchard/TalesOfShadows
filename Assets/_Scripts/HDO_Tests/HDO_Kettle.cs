using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HDO_Kettle : MonoBehaviour
{
    public BoxCollider2D box;
    public ContactFilter2D elisa;
    BoxCollider2D[] result = new BoxCollider2D[1];

    Text text;

    int shouldTalk;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldTalk == 1 && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            
        }
    }
}
