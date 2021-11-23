using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : WindowManager
{
    async void Awake()
    {
        await Task.Delay(5000);
        SceneManager.LoadScene("Main");
        SceneManager.UnloadSceneAsync("Art");
        SceneManager.UnloadSceneAsync("Main");
        ShowWindow("StartMenu");
    }
}
