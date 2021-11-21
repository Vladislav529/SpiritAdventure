using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuWindow : BaseWindow
{
	public Button startButton;
	public Button optionsButton;
	public Button quitButton;


	public override void Awake() 
	{
		base.Awake();
		startButton.onClick.AddListener(StartGame);
		optionsButton.onClick.AddListener(ShowOptions);
		quitButton.onClick.AddListener(QuitGame);
	}

	private void StartGame()
	{
		SceneManager.LoadScene("Game2", LoadSceneMode.Additive);
		SceneManager.LoadScene("Game", LoadSceneMode.Additive);
		_windowManager.CloseWindow(this);
		_windowManager.SetBackgroundImage(null);
	}
	private void ShowOptions()
	{
		_windowManager.ShowWindow("OptionsMenu");
	}
	private void QuitGame()
	{
		_windowManager.ShowWindow("QuitMenu");
	}

	public override void HandleEscapePressed() { }
}
