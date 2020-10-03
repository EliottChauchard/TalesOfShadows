using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HDO_ChooseLevel : MonoBehaviour
{
    Transform self;

    HDO_LevelSelection_Hub lsh;
    HDO_HubObjectAppearance ob;

    float horizontalInput;
    [SerializeField]
    float waitTime, shouldWait;

    public List<Vector2> positions;
    [SerializeField]
    int whatPos;

    // Start is called before the first frame update
    void Start()
    {
        lsh = GameObject.Find("Level Selection").GetComponent<HDO_LevelSelection_Hub>();
        self = GetComponent<Transform>();
        ob = GameObject.Find("Manager").GetComponent<HDO_HubObjectAppearance>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (lsh.selectorMovement)
        {
            waitTime -= 0.01f;

            if (Input.GetKeyDown(KeyCode.RightArrow) || (horizontalInput >= 0.5f && waitTime <=0) || Input.GetKeyDown(KeyCode.JoystickButton8))
            {
                whatPos++;
                if (whatPos > 2)
                {
                    whatPos = 0;
                }
                waitTime = shouldWait;

            }

            if ((horizontalInput <= -0.5f && waitTime <= 0) || Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                whatPos--;
                if (whatPos < 0)
                {
                    whatPos = 2;
                }
                waitTime = shouldWait;

            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Time.timeScale = 1;

                if (whatPos == 0)
                {
                    SceneManager.LoadScene(2);
                }

                if(whatPos == 1)
                {
                    SceneManager.LoadScene(12);
                }

                if(whatPos == 2)
                {
                    SceneManager.LoadScene(11);
                }
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Escape))
            {
                lsh.selectorMovement = false;
                ob.number = 0;
            }

            self.position = positions[whatPos];

        }
        else
        {
            waitTime = 0;
            whatPos = 0;
            self.position = positions[whatPos];
        }
        
    }
}
