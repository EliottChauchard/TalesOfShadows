using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_Timer : MonoBehaviour
{
    
    public float totalTimeInSeconds;
    [SerializeField]
    private int minutesToDisplayValue;
    [SerializeField]
    private int secondsToDisplayValue;

    private Text textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTimeInSeconds += Time.deltaTime;

        minutesToDisplayValue = (int) (totalTimeInSeconds / 60);

        secondsToDisplayValue = (int) totalTimeInSeconds - minutesToDisplayValue * 60;

        textToDisplay.text = minutesToDisplayValue + " : " + secondsToDisplayValue;
    }
}
