using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScoreValues : MonoBehaviour
{
    public static float bestScore, actualTotalScore,
        imagesCollected, keysCollected, activateBasicLever, activateOneKeyMachine, activateTwoKeyMachine, activateThreeKeyMachine,
        littleEnemyKilled, mediumEnemyKilled,
        playerDeaths, endLevel,
        timerScore;
}

public class ELC_ScoreScript : MonoBehaviour
{
    [SerializeField]
    private float Score;

    [SerializeField]
    private float imagesScore, keyScore, basicLeverScore, oneKeyMachineScore, twoKeyMachineScore, threeKeyMachineScore,
        killLittleEnemyScore, killMediumEnemyScore,
        percentOfLoosedScorePerDeath, endLevelScore,
        maxTimeScore;

    // Update is called once per frame
    void Update()
    {
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
