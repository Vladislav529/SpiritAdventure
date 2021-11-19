using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : BaseWindow
{
	public Button continueButton;
	public Button loadButton;
	public Button optionsButton;
	public Button quitButton;


	public override void Awake()
	{
		base.Awake();
		continueButton.onClick.AddListener(ContinueGame);
		loadButton.onClick.AddListener(LoadGame);
		optionsButton.onClick.AddListener(ShowOptions);
		quitButton.onClick.AddListener(QuitGame);
	}

	private void ContinueGame()
	{
		_windowManager.CloseWindow(this);
	}
	private void LoadGame()
    {
		return; // Õ¿œ»—¿“‹
    }
	private void ShowOptions()
	{
		_windowManager.ShowWindow("OptionsMenu");
	}
	private void QuitGame()
	{
		_windowManager.ShowWindow("QuitPauseMenu");
	}
}
