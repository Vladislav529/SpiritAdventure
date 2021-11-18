using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    public WindowManager windowManager;
    // Start is called before the first frame update
    void Awake()
    {
        windowManager.ShowWindow("StartMenu");
    }
}
