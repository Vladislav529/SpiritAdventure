using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{
    private List<BaseWindow> openedWindows = new List<BaseWindow>();
    public GameObject character;
    public GameObject girl;
    private float endDistance = 3f;

    [SerializeField] private Image _bgLayer;
    [SerializeField] private RectTransform _windowLayer;

    [System.Obsolete]
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (openedWindows.Count > 0)
            {
                GetLastOpenedWindow().HandleEscapePressed();
            }
            else
            {
                ShowWindow("PauseMenu");
            }
        }
        if (Vector3.Distance(character.transform.position, girl.transform.position) < endDistance)
        {
            ShowWindow("EndGameWindow");
            //Thread.Sleep(5000);
            SceneManager.LoadScene("Main");
            _ = SceneManager.UnloadScene("Art");
            _ = SceneManager.UnloadScene("Game");
            ShowWindow("StartMenu");
        }
    }

    private BaseWindow GetLastOpenedWindow()
    {
        return openedWindows[openedWindows.Count - 1];
    }

    public void ShowWindow(string prefabName)
    {
        var prototype = Resources.Load<BaseWindow>(prefabName);
        var window = GameObject.Instantiate<BaseWindow>(prototype, _windowLayer.transform);
        window.Init(this);
        window.closeEvent.AddListener(CloseWindow);
        if (openedWindows.Count > 0)
        {
            CollapseWindow(GetLastOpenedWindow());
        }
        openedWindows.Add(window);
    }

    public void CloseWindow(BaseWindow window)
    {
        Destroy(window.gameObject);
        openedWindows.Remove(window);
        if (openedWindows.Count > 0)
        {
            ExpandWindow(GetLastOpenedWindow());
        }
    }

    public void ExpandWindow(BaseWindow window)
    {
        window.gameObject.SetActive(true);
    }

    public void CollapseWindow(BaseWindow window)
    {
        window.gameObject.SetActive(false);
    }

    private static readonly Color transparentColor = new Color(0, 0, 0, 0);
    
    public void SetBackgroundImage(string imagePath, Color color)
    {
        print("Set Background 2");
        if (string.IsNullOrEmpty(imagePath))
        {
            _bgLayer.sprite = null;
            _bgLayer.color = transparentColor;
        }
        else
        {
            _bgLayer.sprite = Resources.Load<Sprite>(imagePath);
            _bgLayer.color = color;
        }
    }
    
    public void SetBackgroundImage(string imagePath)
    {
        print("Set Background");
        SetBackgroundImage(imagePath, _bgLayer.color);
    }
}
