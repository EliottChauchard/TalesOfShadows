using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuButton;
    [SerializeField]
    private GameObject OptionsButton;
    public bool isPaused;
    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            Time.timeScale = 0f;
            MenuButton.SetActive(true);
            OptionsButton.SetActive(true);
            AudioListener.volume = 0.4f;
        }
        else
        {
            Time.timeScale = 1f;
            MenuButton.SetActive(false);
            OptionsButton.SetActive(false);
            AudioListener.volume = PlayerPrefs.GetFloat("GlobalVolume");
        }
    }
}
