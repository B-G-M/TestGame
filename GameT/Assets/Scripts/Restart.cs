using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public Button restartButton;
	public Button otherButton1;
	public Button otherButton2;
	public Button pauseButton;
	public Button menuButton;
	public string lvlName;

	void Start()
	{
		restartButton.gameObject.SetActive(false);
		otherButton1.gameObject.SetActive(true);
		otherButton2.gameObject.SetActive(true);
	}

	public void GameOver()
	{
		Time.timeScale = 0f;

		restartButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);

		otherButton1.gameObject.SetActive(false);
		otherButton2.gameObject.SetActive(false);
		pauseButton.gameObject.SetActive(false);
	}

	public void RestartLevel()
	{
		Time.timeScale = 1f;  
		SceneManager.LoadScene(lvlName);
	}
}
