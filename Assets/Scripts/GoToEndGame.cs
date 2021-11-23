using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEndGame : BaseWindow
{
    public GameObject character;
    private float endDistance = 6f;
    private bool isEnd = false;

    public void Update()
    {
        if (Vector3.Distance(character.transform.position, this.transform.position) < endDistance && !isEnd)
        {
            _windowManager.ShowWindow("EndGameWindow");
            isEnd = true;
        }
    }
}
