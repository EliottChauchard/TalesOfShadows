using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HDO_Hub_Options : MonoBehaviour
{
    BoxCollider2D box;
    BoxCollider2D[] result = new BoxCollider2D[1];
    [SerializeField]
    ContactFilter2D eliza;

    HDO_HubObjectAppearance ob;

    public int whatScene;
    int touched;

    // Start is called before the first frame update
    void Start()
    {
        ob = GameObject.Find("Manager").GetComponent<HDO_HubObjectAppearance>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        touched = Physics2D.OverlapCollider(box, eliza, result);

        if(touched >= 1 && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            ob.number = whatScene;
            
        }
        if(whatScene == 1 && ob.number == 1)
        {
            SceneManager.LoadScene(1);
        }

       
    }
}
