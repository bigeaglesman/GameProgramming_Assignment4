using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;
	public GameObject obstacle4;
	public GameObject obstacle5;

	public float playtime = 50f;
	GameObject[] obstacles;


	public float startTime;

	public float spawnRate;

	public float spawnRadius = 20f;
	public float spawnMinRadius = 5f;

	private static System.Random random = new System.Random();
	private bool spawningActive = true;

	Terrain terrain;
	Vector3 terrainPosition;
	Vector3 terrainSize;
	public GameObject Player;
	private Transform playerTransform;

	void Start()
	{
		obstacles = new GameObject[5];
		obstacles[0] = obstacle1;
		obstacles[1] = obstacle2;
		obstacles[2] = obstacle3;
		obstacles[3] = obstacle4;
		obstacles[4] = obstacle5;
		playerTransform = Player.transform;
		StartCoroutine(SpawnObstacleWave());
		StartCoroutine(StopSpawningObstacle(playtime));
		terrain = Terrain.activeTerrain;
		terrainPosition = terrain.transform.position;
		terrainSize = terrain.terrainData.size;
	}

	IEnumerator SpawnObstacleWave()
	{
		yield return new WaitForSeconds(startTime);

		while (spawningActive)
		{
			SpawnObstacle();

			yield return new WaitForSeconds(spawnRate);
		}
	}

	void SpawnObstacle()
	{
		Vector3 spawnDirection = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * playerTransform.forward;
		Vector3 spawnPosition = playerTransform.position + spawnDirection * Random.Range(spawnMinRadius, spawnRadius);
		spawnPosition.x = Mathf.Clamp(spawnPosition.x, terrainPosition.x, terrainPosition.x + terrainSize.x);
		spawnPosition.z = Mathf.Clamp(spawnPosition.z, terrainPosition.z, terrainPosition.z + terrainSize.z);
		spawnPosition.y += 15.0f;
		GameObject spawnedObstacle = Instantiate(obstacles[Random.Range(0,4)],spawnPosition, Quaternion.identity);
	}

	IEnumerator StopSpawningObstacle(float time)
    {
        yield return new WaitForSeconds(time);
        spawningActive = false;
    }
}
