using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_LevelSelection_Hub : MonoBehaviour
{

    [SerializeField]
    SpriteRenderer lvl1, lvl2, lvl3, selector;

    public bool selectorMovement;

    HDO_HubObjectAppearance ob;

    // Start is called before the first frame update
    void Start()
    {
        ob = GameObject.Find("Manager").GetComponent<HDO_HubObjectAppearance>();

    }

    // Update is called once per frame
    void Update()
    {
        if(ob.number == 1)
        {
            selectorMovement = true;
            lvl1.enabled = true;
            lvl2.enabled = true;
            lvl3.enabled = true;
            selector.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            if(ob.number != 3)
            {
                Time.timeScale = 1;
            }
            selectorMovement = false;
            lvl1.enabled = false;
            lvl2.enabled = false;
            lvl3.enabled = false;
            selector.enabled = false;
        }
    }
}
