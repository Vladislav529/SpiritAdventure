using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : WindowManager
{
    [Obsolete]
    async void Awake()
    {
        await Task.Delay(5000);
        _ = SceneManager.UnloadScene("Art");
        _ = SceneManager.UnloadScene("Main");
        _ = SceneManager.UnloadScene("Game");
        SceneManager.LoadScene("Main");
        ShowWindow("StartMenu");
    }
}
