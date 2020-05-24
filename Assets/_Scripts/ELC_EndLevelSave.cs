using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ELC_EndLevelSave : MonoBehaviour
{
    private bool playerIsAtTheEnd;
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
        if(playerIsAtTheEnd == true)
        {
            //faire les calculs du score en fonction du temps + morts
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
            playerIsAtTheEnd = true;
            StartCoroutine("NextLevel");
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);
    }
}
