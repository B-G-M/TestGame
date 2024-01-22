using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitCounter : MonoBehaviour
{
	public Text counterText;
	public int total = 10;
	private int counter = 0;

	void Start()
	{
		UpdateCounterText();
	}

	public void IncreaseCounter()
	{
		counter++;
		UpdateCounterText();
	}

	void UpdateCounterText()
	{
		counterText.text = counter.ToString() + "/" + total.ToString();

		if (counter == total)
		{
			LevelCompleted();
		}
	}

	void LevelCompleted()
	{
		SceneManager.LoadScene("Menu");
	}
}
