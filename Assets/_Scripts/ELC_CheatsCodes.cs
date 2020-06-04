using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_CheatsCodes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.gameObject.transform.position = new Vector2(-11.675f, -41.826f);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerPrefs.DeleteAll();
        }

        //else if(Input.GetKeyDown(KeyCode.U))
        //{
        //    Time.timeScale = 2f;
        //}
    }
}
