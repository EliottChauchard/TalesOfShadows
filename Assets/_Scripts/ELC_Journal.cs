using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Journal : MonoBehaviour
{
    [SerializeField]
    public int refNumber;
    private int numberSaved;
    
    void Update()
    {
        numberSaved = PlayerPrefs.GetInt("Collectible" + refNumber);

        if(numberSaved == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
