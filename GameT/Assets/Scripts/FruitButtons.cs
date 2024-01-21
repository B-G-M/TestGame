using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitButtons : MonoBehaviour
{
	public Button button1;
	public Button button2;

	public Sprite normalSprite1;
	public Sprite selectedSprite1;

	public Sprite normalSprite2;
	public Sprite selectedSprite2;

	private static bool isBananaButtonPressed = true;
	
	void Start()
	{
		button1.image.sprite = selectedSprite1;
		button2.image.sprite = normalSprite2;

		button1.onClick.AddListener(OnButton1Click);
		button2.onClick.AddListener(OnButton2Click);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ToggleButtons();
		}
	}

	void OnButton1Click()
	{
		isBananaButtonPressed = true;

		button1.image.sprite = selectedSprite1;
		button2.image.sprite = normalSprite2;
	}

	void OnButton2Click()
	{
		isBananaButtonPressed = false;

		button1.image.sprite = normalSprite1;
		button2.image.sprite = selectedSprite2;
	}

	void ToggleButtons()
	{
		isBananaButtonPressed = !isBananaButtonPressed;
		UpdateButtonSprites();
	}

	void UpdateButtonSprites()
	{
		button1.image.sprite = isBananaButtonPressed ? selectedSprite1 : normalSprite1;
		button2.image.sprite = !isBananaButtonPressed ? selectedSprite2 : normalSprite2;
	}

	public bool IsBananaButtonPressed()
	{
		return isBananaButtonPressed;
	}
}
