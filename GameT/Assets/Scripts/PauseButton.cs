using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
	public Button pauseButton;
	public Button resumeButton;
	public Button menuButton;
	public Button otherButton1;
	public Button otherButton2;

	void Start()
	{
		Time.timeScale = 0f;
		menuButton.gameObject.SetActive(false);
		pauseButton.gameObject.SetActive(false);

		pauseButton.onClick.AddListener(PauseGame);
		resumeButton.onClick.AddListener(ResumeGame);
		menuButton.onClick.AddListener(ReturnToMenu);
	}

	void PauseGame()
	{
		Time.timeScale = 0f;
		pauseButton.gameObject.SetActive(false);
		resumeButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);

		otherButton1.gameObject.SetActive(false);
		otherButton2.gameObject.SetActive(false);
	}

	void ResumeGame()
	{
		Time.timeScale = 1f;
		pauseButton.gameObject.SetActive(true);
		resumeButton.gameObject.SetActive(false);
		menuButton.gameObject.SetActive(false);

		otherButton1.gameObject.SetActive(true);
		otherButton2.gameObject.SetActive(true);
	}

	void ReturnToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
