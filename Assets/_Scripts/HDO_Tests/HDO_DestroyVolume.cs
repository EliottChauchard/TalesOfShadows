using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HDO_DestroyVolume : MonoBehaviour
{
    public GameObject self;
    HDO_HubObjectAppearance ob;

    Vector3 origin;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        origin = self.transform.position;
        self.transform.localPosition = new Vector3(10000, 10000, 10000);
        ob = GameObject.Find("Manager").GetComponent<HDO_HubObjectAppearance>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || ob.number == 0)
        {
            self.transform.localPosition = new Vector3(10000, 10000, 10000);
            if(ob.number != 1)
            {
                Time.timeScale = 1;
            }
            slider.enabled = false;
        }

        if(ob.number == 3)
        {
            Time.timeScale = 0;
            self.transform.position = origin;
            slider.enabled = true;
        }
        Debug.Log(PlayerPrefs.GetFloat("GlobalVolume"));
    }
}
