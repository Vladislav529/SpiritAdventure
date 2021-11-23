using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEndGame : MonoBehaviour
{
    public GameObject character;
    public GameObject girl;
    public WindowManager windowManager;
    private float endDistance = 6f;
    private bool isEnd = false;

    public void Update()
    {
        if (Vector3.Distance(character.transform.position, girl.transform.position) < endDistance && !isEnd)
        {
            windowManager.ShowWindow("EndGameWindow");
            isEnd = true;
        }
    }
}
