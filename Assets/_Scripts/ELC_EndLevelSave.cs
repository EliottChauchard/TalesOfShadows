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
    private bool switchSceneDoor;
    [SerializeField]
    private bool teleportDoor;

    [SerializeField]
    private string nextSceneName;
    private int entireScore;

    // Start is called before the first frame update
    void Start()
    {
        GlobalScoreValues.bestScore = PlayerPrefs.GetFloat("BestScore");
    }

    // Update is called once per frame
    void Update()
    {
        positionToTP = objectsPositionToTeleport.GetComponent<Transform>().position;

        if (playerIsAtTheEnd == true && switchSceneDoor == true)
        {
            GlobalScoreValues.actualTotalScore += GlobalScoreValues.timerScore;

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
        yield return new WaitForSeconds(1f);
        if(switchSceneDoor == true)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else if(teleportDoor == true)
        {
            playerGameObject.GetComponent<Transform>().position = positionToTP;
        }
    }
}
