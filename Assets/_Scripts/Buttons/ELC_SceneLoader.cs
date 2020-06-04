using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ELC_SceneLoader : MonoBehaviour
{
    private float progress;
    public Animator animator;
    public float transitionTime = 1f;
    [SerializeField]
    private GameObject toHide;
    [SerializeField]
    private GameObject loadingSprite;
    public ELC_PauseMenu pM;

    public void Start()
    {
        loadingSprite.SetActive(false);
        animator.GetComponent<CanvasGroup>().alpha = 0f;
    }
    

    public void LoadSceneFuction(int SceneIndex)
    {
        if(pM != null)
        {
            pM.isPaused = false;
        }
        
        Time.timeScale = 1f;
        StartCoroutine(LoadSceneAsync(SceneIndex));
    }


    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        if (sceneIndex == 1)
        {
            FindObjectOfType<ELC_AudioManager>().Play("ClickButton", false);
            animator.SetTrigger("Start");
            toHide.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            loadingSprite.SetActive(true);
            yield return new WaitForSeconds(transitionTime);
            AsyncOperation operationPercentage = SceneManager.LoadSceneAsync(sceneIndex);


            while (!operationPercentage.isDone)
            {
                progress = operationPercentage.progress / 0.9f;
                Debug.Log(progress);
                yield return null;
            }
        }
        else
        {
            FindObjectOfType<ELC_AudioManager>().Play("ClickButton", false);
            animator.SetTrigger("Start");
            toHide.SetActive(false);
            AsyncOperation operationPercentage = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operationPercentage.isDone)
            {
                progress = operationPercentage.progress / 0.9f;
                Debug.Log(progress);
                yield return null;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
