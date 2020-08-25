using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_AffichageFinalScore : MonoBehaviour
{
    [SerializeField]
    private float levelNumber;
    private Text textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textToDisplay.text = "Score : " + PlayerPrefs.GetFloat("LastScoreAtLevel" + levelNumber);
    }
}
