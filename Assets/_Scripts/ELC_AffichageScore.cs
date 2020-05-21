using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_AffichageScore : MonoBehaviour
{
    [SerializeField]
    private Text text;
    private float scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = GlobalScoreValues.actualTotalScore;
        text.text = "score : " + scoreValue;
    }
}
