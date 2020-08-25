using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScoreValues : MonoBehaviour
{
    public static float bestScore, actualTotalScore, levelNumber, maxCorruption,
        imagesCollected, keysCollected, activateBasicLever, activateOneKeyMachine, activateTwoKeyMachine, activateThreeKeyMachine,
        littleEnemyKilled, mediumEnemyKilled,
        percentOfLoosedScorePerDeath, playerDeaths, endLevel,
        timerScore, bestTime;
}

public class ELC_ScoreScript : MonoBehaviour
{
    private ELC_Timer timerScript;

    [SerializeField]
    private float Score;
    [SerializeField]
    private float levelNumber;
    [SerializeField]
    private float lastScoreSaved;
    [SerializeField]
    private float bestScoreSaved;

    [SerializeField]
    private float imagesScore, maxCorruption, keyScore, basicLeverScore, oneKeyMachineScore, twoKeyMachineScore, threeKeyMachineScore,
        killLittleEnemyScore, killMediumEnemyScore, playerDeaths,
        percentLoosedScorePerDeath, endLevelScore,
        maxTimeScore;

    private void Start()
    {
        timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<ELC_Timer>();
        GlobalScoreValues.levelNumber = levelNumber;
    }

    // Update is called once per frame
    void Update()
    {
        lastScoreSaved = PlayerPrefs.GetFloat("LastScoreAtLevel" + GlobalScoreValues.levelNumber);
        bestScoreSaved = PlayerPrefs.GetFloat("BestScoreAtLevel" + GlobalScoreValues.levelNumber);
        playerDeaths = GlobalScoreValues.playerDeaths;
        GlobalScoreValues.maxCorruption = maxCorruption;


        if (timerScript.totalTimeInSeconds < maxTimeScore)
        {
            GlobalScoreValues.timerScore = maxTimeScore - timerScript.totalTimeInSeconds;
        }

        GlobalScoreValues.percentOfLoosedScorePerDeath = percentLoosedScorePerDeath;

        Score = GlobalScoreValues.actualTotalScore;

        GlobalScoreValues.actualTotalScore =
            GlobalScoreValues.imagesCollected * imagesScore +
            GlobalScoreValues.keysCollected * keyScore +
            GlobalScoreValues.activateBasicLever * basicLeverScore +
            GlobalScoreValues.activateOneKeyMachine * oneKeyMachineScore +
            GlobalScoreValues.activateTwoKeyMachine * twoKeyMachineScore +
            GlobalScoreValues.activateThreeKeyMachine * threeKeyMachineScore +
            GlobalScoreValues.littleEnemyKilled * killLittleEnemyScore +
            GlobalScoreValues.mediumEnemyKilled * killMediumEnemyScore +
            GlobalScoreValues.endLevel * endLevelScore;
    }
}
