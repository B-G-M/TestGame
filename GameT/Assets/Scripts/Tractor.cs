using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{
	public float speed = 5f;

	private FruitButtons FruitButtons = new FruitButtons();
	private Vector3 lastMoveDirection = Vector3.left;
	private Vector3 inputDirection = Vector3.zero;

	void Start()
	{
		transform.position = new Vector3(1f, 10.3f, 9);
	}

	void Update()
	{
		MoveOnPoints();
	}

	void MoveOnPoints()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		float accuracy = 0.01f;

		if (Mathf.Abs(horizontal) > 0.1f ^ Mathf.Abs(vertical) > 0.1f)
		{
			inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
			inputDirection = Vector3.ClampMagnitude(inputDirection, 1f);
		}

		if (inputDirection != Vector3.zero)
		{
			if (Mathf.Abs(transform.localPosition.x - Mathf.Round(transform.localPosition.x)) < accuracy &&
				Mathf.Abs(transform.localPosition.z - Mathf.Round(transform.localPosition.z)) < accuracy)
			{
				transform.localPosition = new Vector3(Mathf.Round(transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Round(transform.localPosition.z));

				lastMoveDirection = inputDirection;
				Quaternion targetRotation = Quaternion.LookRotation(lastMoveDirection, Vector3.up);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90f);
			}
		}

		transform.Translate(lastMoveDirection * speed * Time.deltaTime, Space.World);

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, 1f, 9f),
			transform.position.y,
			Mathf.Clamp(transform.position.z, 1f, 9f)
		);
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Fruit1"))
		{
			if(FruitButtons.IsBananaButtonPressed())
				Destroy(other.gameObject);
		}
		else if (other.CompareTag("Fruit2"))
		{
			if (!FruitButtons.IsBananaButtonPressed())
				Destroy(other.gameObject);
		}
	}
}
