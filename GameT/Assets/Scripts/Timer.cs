using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float timeLimit = 60f; 
	private float currentTime;

	public Text timerText;

	void Start()
	{
		currentTime = timeLimit;
		UpdateTimerText();
	}

	void Update()
	{
		currentTime -= Time.deltaTime;

		if (currentTime <= 0)
		{
			timerText.enabled = false;
			FindObjectOfType<Restart>().GameOver();
		}

		UpdateTimerText();
	}

	void UpdateTimerText()
	{
		timerText.text = Mathf.CeilToInt(currentTime).ToString();
	}
}
