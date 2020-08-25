using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ELC_EndLevelSave : MonoBehaviour
{
    [SerializeField]
    private GameObject objectsPositionToTeleport;
    [SerializeField]
    private GameObject playerGameObject;

    [SerializeField]
    private Vector3 playerPosition;
    [SerializeField]
    private Vector3 positionToTP;
    private bool playerIsAtTheEnd;
    private bool hasBeenTriggered;
    

    [SerializeField]
    private ELC_Timer timerScript;
    private float time;

    [SerializeField]
    private bool switchSceneDoor;
    [SerializeField]
    private bool teleportDoor;
    [SerializeField]
    private bool finalScoreDoor;

    [SerializeField]
    private string nextSceneName;
    private int entireScore;

    public Animator crossFade;
    [SerializeField]
    private float crossFadeTime;

    private float corruption;

    [SerializeField]
    private float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        GlobalScoreValues.bestScore = PlayerPrefs.GetFloat("BestScoreAtLevel" + GlobalScoreValues.levelNumber);
        timerScript = timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<ELC_Timer>();
        GlobalScoreValues.bestTime = PlayerPrefs.GetFloat("BestTimeAtlevel" + GlobalScoreValues.levelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        positionToTP = objectsPositionToTeleport.GetComponent<Transform>().position;
        time = timerScript.totalTimeInSeconds;

        if (playerIsAtTheEnd == true && switchSceneDoor == true && finalScoreDoor == false)
        {
            GlobalScoreValues.actualTotalScore += GlobalScoreValues.timerScore;

            PlayerPrefs.SetFloat("LastTime", time);
            if(time < PlayerPrefs.GetFloat("BestTimeAtLevel" + GlobalScoreValues.levelNumber) || PlayerPrefs.GetFloat("BestTimeAtLevel" + GlobalScoreValues.levelNumber) == 0)
            {
                PlayerPrefs.SetFloat("BestTimeAtLevel" + GlobalScoreValues.levelNumber, time);
            }

            for(int i = 0; i < GlobalScoreValues.playerDeaths; i++)
            {
                GlobalScoreValues.actualTotalScore = GlobalScoreValues.actualTotalScore * GlobalScoreValues.percentOfLoosedScorePerDeath;
            }


            corruption = GlobalScoreValues.playerDeaths / GlobalScoreValues.maxCorruption * 100;
            //PlayerPrefs.SetFloat("BestCorruptionAtLevel" + GlobalScoreValues.levelNumber, corruption);
            if (corruption < PlayerPrefs.GetFloat("BestCorruptionAtLevel" + GlobalScoreValues.levelNumber) || PlayerPrefs.HasKey("BestCorruptionAtLevel" + GlobalScoreValues.levelNumber) == false)
            {
                PlayerPrefs.SetFloat("BestCorruptionAtLevel" + GlobalScoreValues.levelNumber, corruption);
            }
            

            entireScore = (int)GlobalScoreValues.actualTotalScore;
            GlobalScoreValues.actualTotalScore = entireScore;

            PlayerPrefs.SetFloat("LastScoreAtLevel" + GlobalScoreValues.levelNumber, GlobalScoreValues.actualTotalScore);

            GlobalScoreValues.bestScore = PlayerPrefs.GetFloat("BestScoreAtLevel" + GlobalScoreValues.levelNumber);

            if (GlobalScoreValues.bestScore < GlobalScoreValues.actualTotalScore)
            {
                PlayerPrefs.SetFloat("BestScoreAtLevel" + GlobalScoreValues.levelNumber, GlobalScoreValues.actualTotalScore);
            }
            playerIsAtTheEnd = false;
        }
        else if(playerIsAtTheEnd == true && switchSceneDoor == true && finalScoreDoor == true)
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

            StartCoroutine("NextLevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(hasBeenTriggered == false)
            {
                playerGameObject = collision.gameObject;
                playerPosition = playerGameObject.GetComponent<Transform>().localPosition;
                playerIsAtTheEnd = true;
                StartCoroutine("NextLevel");
                Debug.Log("PlayerRegister");
            }

            hasBeenTriggered = true;
        }
    }
    IEnumerator NextLevel()
    {
        //yield return new WaitForSeconds(1f);
        if(switchSceneDoor == true)
        {
            crossFade.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(nextSceneName);
        }
        else if(teleportDoor == true) 
        {
            crossFade.SetTrigger("Start");
            yield return new WaitForSeconds(crossFadeTime);
            playerGameObject.GetComponent<Transform>().position = positionToTP;
            yield return new WaitForSeconds(0.5f);
            crossFade.SetTrigger("Restart");

        }
    }
}
