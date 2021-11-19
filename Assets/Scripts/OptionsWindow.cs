using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //������ � ������������
using UnityEngine.SceneManagement; //������ �� �������
using UnityEngine.Audio; //������ � �����

public class OptionsWindow : BaseWindow
{
    public float volume = 0; //���������
    public bool isFullscreen = false; //������������� �����
	public int currResolutionIndex = 0; //������� ����������

	public AudioMixer audioMixer; //��������� ���������
    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������

	public Toggle toggle;
	public Dropdown dropdown;
	public Slider slider;
	public Button saveButton;
	public Button exitButton;

	public void ChangeVolume(float val) //��������� �����
    {
        volume = val;
    }
    public void ChangeResolution(int index) //��������� ����������
    {
        currResolutionIndex = index;
    }
	public void ChangeFullscreenMode(bool val) //��������� ��� ���������� �������������� ������
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
//	public float volume = 0; //���������
//	public int quality = 0; //��������
//	public bool isFullscreen = false; //������������� �����
//	public AudioMixer audioMixer; //��������� ���������
//	public Dropdown resolutionDropdown; //������ � ������������ ��� ����
//	private Resolution[] resolutions; //������ ��������� ����������
//	private int currResolutionIndex = 0; //������� ����������

//	public void ChangeVolume(float val) //��������� �����
//	{
//		volume = val;
//	}
//	public void ChangeResolution(int index) //��������� ����������
//	{
//		currResolutionIndex = index;
//	}
//	public void ChangeFullscreenMode(bool val) //��������� ��� ���������� �������������� ������
//	{
//		isFullscreen = val;
//	}
//	public void ChangeQuality(int index) //��������� ��������
//	{
//		quality = index;
//	}

//	public void SaveSettings()
//	{
//		audioMixer.SetFloat("MasterVolume", volume); //��������� ������ ���������
//		QualitySettings.SetQualityLevel(quality); //��������� ��������
//		Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
//		Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
//	}

//	public void AutoSettings()
//	{
//		resolutionDropdown.ClearOptions(); //�������� ������ �������
//		resolutions = Screen.resolutions; //��������� ��������� ����������
//		List<string> options = new List<string>(); //�������� ������ �� ���������� ����������

//		for (int i = 0; i < resolutions.Length; i++) //���������� ������ � ������ �����������
//		{
//			string option = resolutions[i].width + " x " + resolutions[i].height; //�������� ������ ��� ������
//			options.Add(option); //���������� ������ � ������

//			if (resolutions[i].Equals(Screen.currentResolution)) //���� ������� ���������� ����� ������������
//			{
//				currResolutionIndex = i; //�� ���������� ��� ������
//			}
//		}

//		resolutionDropdown.AddOptions(options); //���������� ��������� � ���������� ������
//		resolutionDropdown.value = currResolutionIndex; //��������� ������ � ������� �����������
//		resolutionDropdown.RefreshShownValue(); //���������� ������������� ��������
//	}
//}
