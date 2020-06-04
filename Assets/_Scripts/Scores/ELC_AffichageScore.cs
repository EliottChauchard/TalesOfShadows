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
        GlobalScoreValues.playerDeaths = 0f;
        GlobalScoreValues.activateBasicLever = 0f;
        GlobalScoreValues.activateOneKeyMachine = 0f;
        GlobalScoreValues.activateThreeKeyMachine = 0f;
        GlobalScoreValues.activateTwoKeyMachine = 0f;
        GlobalScoreValues.keysCollected = 0f;
        GlobalScoreValues.littleEnemyKilled = 0f;
        GlobalScoreValues.mediumEnemyKilled = 0f;
        GlobalScoreValues.playerDeaths = 0f;
        GlobalScoreValues.actualTotalScore = 0f;
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = GlobalScoreValues.actualTotalScore;
        text.text = "score : " + scoreValue;
    }
}
