using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_AffichageBestTime : MonoBehaviour
{
    private Text textToDisplay;
    private float minutesToDisplayValue;
    private float secondsToDisplayValue;
    private float totalTimeInSeconds;
    [SerializeField]
    private float levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTimeInSeconds = PlayerPrefs.GetFloat("BestTimeAtLevel" + levelNumber);

        minutesToDisplayValue = (int)(totalTimeInSeconds / 60);

        secondsToDisplayValue = (int)totalTimeInSeconds - minutesToDisplayValue * 60;

        textToDisplay.text = minutesToDisplayValue + " : " + secondsToDisplayValue;

        textToDisplay.text = "Best Time : " + minutesToDisplayValue + " : " + secondsToDisplayValue;
    }
}
