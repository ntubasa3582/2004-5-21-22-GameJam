using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    static SceneScript instance = default;
    public static SceneScript Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = GetComponent<SceneScript>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeScene(string sceneName)
    {
            SceneManager.LoadScene(sceneName);
    }
}
