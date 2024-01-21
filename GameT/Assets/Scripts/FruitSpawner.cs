using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
	{
	public GameObject fruitType1; 
	public GameObject fruitType2;

	public int gridSize = 9; 
	public float spacing = 1.0f; 
	public int totalFruits = 10;

	private List<Vector3> occupiedPositions = new List<Vector3>(); 

	void Start()
	{
		SpawnFruits();
	}

	void SpawnFruits()
	{
		for (int i = 0; i < totalFruits; i++)
		{
			Vector3 spawnPosition = GetRandomUnoccupiedPosition();

			GameObject fruitToSpawn = Random.Range(0, 2) == 0 ? fruitType1 : fruitType2; 
			GameObject spawnedFruit = Instantiate(fruitToSpawn, spawnPosition, Quaternion.identity);
			
			spawnedFruit.transform.Rotate(-90f, 0f, 0f);
			
			spawnedFruit.transform.localScale /= 4f;

			Collider fruitCollider = spawnedFruit.AddComponent<BoxCollider>();
			Rigidbody fruitRigidbody = spawnedFruit.AddComponent<Rigidbody>();
			fruitRigidbody.isKinematic = true; 

			occupiedPositions.Add(spawnPosition);
		}
	}

	Vector3 GetRandomUnoccupiedPosition()
	{
		Vector3 position;
		do
		{
			//пофиксить возможный спавн в игроке 
			int x = Random.Range(1, gridSize + 1);
			int z = Random.Range(1, gridSize + 1);
			position = new Vector3(x * spacing, 10.3f, z * spacing);
		} while (occupiedPositions.Contains(position));

		return position;
	}
}
