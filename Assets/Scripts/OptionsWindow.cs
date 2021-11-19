using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио

public class OptionsWindow : BaseWindow
{
    public float volume = 0; //Громкость
    public bool isFullscreen = false; //Полноэкранный режим
	public int currResolutionIndex = 0; //Текущее разрешение

	public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений

	public Toggle toggle;
	public Dropdown dropdown;
	public Slider slider;
	public Button saveButton;
	public Button exitButton;

	public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }
    public void ChangeResolution(int index) //Изменение разрешения
    {
        currResolutionIndex = index;
    }
	public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
	{
		isFullscreen = val;
	}

	public override void Awake()
	{
		Debug.Log("Options.Awake()");
		base.Awake();
		LoadSettings();
		saveButton.onClick.AddListener(SaveSettings);
		exitButton.onClick.AddListener(ReturnToMain);
	}

	private void ReturnToMain()
	{
		_windowManager.CloseWindow(this);
	}

	public void SaveSettings()
	{
		PlayerPrefs.SetInt("currResolutionIndex", currResolutionIndex);
		if (isFullscreen)
        {
			PlayerPrefs.SetInt("isFullscreen", 1);
		}
		else
        {
			PlayerPrefs.DeleteKey("isFullscreen");
		}
		PlayerPrefs.SetFloat("volume", volume);
		PlayerPrefs.Save();
		Debug.Log("Game data saved!");
	}

	public void LoadSettings()
	{
		currResolutionIndex = PlayerPrefs.GetInt("currResolutionIndex", currResolutionIndex);
		isFullscreen = PlayerPrefs.HasKey("isFullscreen");
		volume = PlayerPrefs.GetFloat("volume", volume);
		dropdown.value = currResolutionIndex;
		toggle.isOn = isFullscreen;
		slider.value = volume;
		Debug.Log("Game data loaded!");
	}
}

//public class Options2 : BaseWindow
//{
//	public float volume = 0; //Громкость
//	public int quality = 0; //Качество
//	public bool isFullscreen = false; //Полноэкранный режим
//	public AudioMixer audioMixer; //Регулятор громкости
//	public Dropdown resolutionDropdown; //Список с разрешениями для игры
//	private Resolution[] resolutions; //Список доступных разрешений
//	private int currResolutionIndex = 0; //Текущее разрешение

//	public void ChangeVolume(float val) //Изменение звука
//	{
//		volume = val;
//	}
//	public void ChangeResolution(int index) //Изменение разрешения
//	{
//		currResolutionIndex = index;
//	}
//	public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
//	{
//		isFullscreen = val;
//	}
//	public void ChangeQuality(int index) //Изменение качества
//	{
//		quality = index;
//	}

//	public void SaveSettings()
//	{
//		audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
//		QualitySettings.SetQualityLevel(quality); //Изменение качества
//		Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
//		Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //Изменения разрешения
//	}

//	public void AutoSettings()
//	{
//		resolutionDropdown.ClearOptions(); //Удаление старых пунктов
//		resolutions = Screen.resolutions; //Получение доступных разрешений
//		List<string> options = new List<string>(); //Создание списка со строковыми значениями

//		for (int i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
//		{
//			string option = resolutions[i].width + " x " + resolutions[i].height; //Создание строки для списка
//			options.Add(option); //Добавление строки в список

//			if (resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
//			{
//				currResolutionIndex = i; //То получается его индекс
//			}
//		}

//		resolutionDropdown.AddOptions(options); //Добавление элементов в выпадающий список
//		resolutionDropdown.value = currResolutionIndex; //Выделение пункта с текущим разрешением
//		resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения
//	}
//}
