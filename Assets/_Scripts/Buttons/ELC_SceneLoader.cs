using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ELC_SceneLoader : MonoBehaviour
{
    private float progress;

    public void LoadSceneFuction(int SceneIndex)
    {
        StartCoroutine(LoadSceneAsync(SceneIndex));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        FindObjectOfType<ELC_AudioManager>().Play("ClickButton", false);
        AsyncOperation operationPercentage = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operationPercentage.isDone)
        {
            progress = operationPercentage.progress / 0.9f;
            Debug.Log(progress);
            yield return null;
        }
    }
}
