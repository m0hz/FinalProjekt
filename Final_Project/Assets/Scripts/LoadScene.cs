using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]

public class LoadScene : MonoBehaviour
{

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
