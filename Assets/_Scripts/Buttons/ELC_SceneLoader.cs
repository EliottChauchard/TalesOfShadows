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
    public bool isPause;

    public void Start()
    {
        loadingSprite.SetActive(false);
    }

    public void LoadSceneFuction(int SceneIndex)
    {
        StartCoroutine(LoadSceneAsync(SceneIndex));
    }


    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        if (isPause == false)
        {
            if (sceneIndex == 1)
            {
                FindObjectOfType<ELC_AudioManager>().Play("ClickButton", false);
                animator.SetTrigger("MenuStart");
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
                animator.SetTrigger("MenuStart");
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
        else
        {
            FindObjectOfType<ELC_AudioManager>().Play("ClickButton", false);
            animator.SetTrigger("Start");
            AsyncOperation operationPercentage = SceneManager.LoadSceneAsync(sceneIndex);
            Debug.Log(sceneIndex);

            while (!operationPercentage.isDone)
            {
                progress = operationPercentage.progress / 0.9f;
                Debug.Log(progress);
                yield return null;
            }
        }
            
    }
}
