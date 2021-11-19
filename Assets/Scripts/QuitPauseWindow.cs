using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitPauseWindow : BaseWindow
{
    public Button menuButton;
	public Button exitButton;

	public override void Awake()
	{
		base.Awake();
		menuButton.onClick.AddListener(ReturnToMain);
		exitButton.onClick.AddListener(QuitTheGame);
	}

	private void ReturnToMain()
	{
		_windowManager.CloseWindow(this);
	}
	private void QuitTheGame()
	{
		SceneManager.LoadScene("Main");
	}
}
