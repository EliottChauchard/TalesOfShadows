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

    [SerializeField]
    private float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        GlobalScoreValues.bestScore = PlayerPrefs.GetFloat("BestScore");
        timerScript = timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<ELC_Timer>();
        GlobalScoreValues.bestTime = PlayerPrefs.GetFloat("BestTime");
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
            if(time < PlayerPrefs.GetFloat("BestTime") || PlayerPrefs.GetFloat("BestTime") == 0)
            {
                PlayerPrefs.SetFloat("BestTime", time);
            }

            for(int i = 0; i < GlobalScoreValues.playerDeaths; i++)
            {
                GlobalScoreValues.actualTotalScore = GlobalScoreValues.actualTotalScore * GlobalScoreValues.percentOfLoosedScorePerDeath;
            }

            entireScore = (int)GlobalScoreValues.actualTotalScore;
            GlobalScoreValues.actualTotalScore = entireScore;

            PlayerPrefs.SetFloat("LastScore", GlobalScoreValues.actualTotalScore);

            GlobalScoreValues.bestScore = PlayerPrefs.GetFloat("BestScore");

            if (GlobalScoreValues.bestScore < GlobalScoreValues.actualTotalScore)
            {
                PlayerPrefs.SetFloat("BestScore", GlobalScoreValues.actualTotalScore);
            }
            playerIsAtTheEnd = false;
        }
        else if(playerIsAtTheEnd == true && switchSceneDoor == true && finalScoreDoor == true)
        {
            GlobalScoreValues.playerDeaths = 0f;
            StartCoroutine("NextLevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerGameObject = collision.gameObject;
            playerPosition = playerGameObject.GetComponent<Transform>().localPosition;
            playerIsAtTheEnd = true;
            StartCoroutine("NextLevel");
            Debug.Log("PlayerRegister");
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
