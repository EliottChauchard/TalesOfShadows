using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ELC_PlayButton : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        this.button.onClick.AddListener(LevelSwitch);
    }

    void LevelSwitch()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
