using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : BaseWindow
{
	public Button continueButton;
	public Button loadButton;
	public Button optionsButton;
	public Button quitButton;


	public override void Awake()
	{
		base.Awake();
		continueButton.onClick.AddListener(ReturnToGame);
		loadButton.onClick.AddListener(LoadGame);
		optionsButton.onClick.AddListener(ShowOptions);
		quitButton.onClick.AddListener(QuitGame);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_windowManager.CloseWindow(this);
		}
	}

	private void ReturnToGame()
	{
		_windowManager.CloseWindow(this);
	}
	private void LoadGame()
    {
		return; // «¿√–”« ” »√–€ —ƒ≈À¿“‹
    }
	private void ShowOptions()
	{
		_windowManager.ShowWindow("OptionsMenu");
	}
	private void QuitGame()
	{
		_windowManager.ShowWindow("QuitMainMenu");
	}
}
