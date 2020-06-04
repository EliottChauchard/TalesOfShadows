using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_AffichageNombreClés : MonoBehaviour
{
    [SerializeField]
    private Text textToDisplay;
    private float playerNumberOfKeys;
    private ELC_Collectibles CollectiblesScript;

    private void Start()
    {
        CollectiblesScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ELC_Collectibles>();
        textToDisplay = this.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        playerNumberOfKeys = CollectiblesScript.numberOfKeys;

        textToDisplay.text = "" + playerNumberOfKeys;
    }
}
