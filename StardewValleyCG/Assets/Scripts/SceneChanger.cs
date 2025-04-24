using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
