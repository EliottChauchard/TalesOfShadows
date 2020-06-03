using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_AffichageNombreJournaux : MonoBehaviour
{
    private Text textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textToDisplay.text = "Total papers Collected : " + PlayerPrefs.GetInt("NumberOfCollectibles");
    }
}
