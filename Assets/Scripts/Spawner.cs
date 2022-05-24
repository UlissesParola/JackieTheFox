using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Pool Pool;
	public float VerticalAxisSpawnRange;
	public float MinSpawnTimeInterval;
	public float MaxSpawnTimeInterval;

	private Vector3 SpawnPositionRange;
	private float counter;
	private float _spawnTime;

	// Use this for initialization
	void Start () {
		float width = Camera.main.orthographicSize * Camera.main.aspect;
		transform.position = new Vector3(width + 3, transform.position.y);
		_spawnTime = Random.Range(MinSpawnTimeInterval, MaxSpawnTimeInterval);
	}
    private void Update()
    {
		counter += Time.deltaTime;

		if (counter >= _spawnTime)
        {
			Spawn();
			_spawnTime = Random.Range(MinSpawnTimeInterval, MaxSpawnTimeInterval);
			counter = 0;
		}
    }

    private void Spawn()
	{
		GameObject enemyPrefab = Pool.InstantiatePoolObject(Random.Range(0, (Pool.PoolSize)));
		Vector3 spawnPosition = new Vector3 (this.transform.position.x, Random.Range(VerticalAxisSpawnRange, -VerticalAxisSpawnRange));
		enemyPrefab.transform.position = spawnPosition;
	}
}
