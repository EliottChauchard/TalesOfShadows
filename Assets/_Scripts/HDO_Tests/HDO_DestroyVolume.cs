using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_DestroyVolume : MonoBehaviour
{
    public GameObject self;
    HDO_HubObjectAppearance ob;

    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = self.transform.position;
        self.transform.localPosition = new Vector3(10000, 10000, 10000);
        ob = GameObject.Find("Manager").GetComponent<HDO_HubObjectAppearance>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            self.transform.localPosition = new Vector3(10000, 10000, 10000);
            ob.number = 0;
            Time.timeScale = 1;
        }

        if(ob.number == 3)
        {
            Time.timeScale = 0;
            self.transform.position = origin;
        }
    }
}
