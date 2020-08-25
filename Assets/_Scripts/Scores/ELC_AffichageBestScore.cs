using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_AffichageBestScore : MonoBehaviour
{
    private Text textToDisplay;
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
        textToDisplay.text = "Best Score at level " + levelNumber + ": " + PlayerPrefs.GetFloat("BestScoreAtLevel" + levelNumber);
    }
}
