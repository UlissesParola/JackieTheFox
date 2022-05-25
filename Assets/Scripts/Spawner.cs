using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float VerticalAxisSpawnRange;
	public float MinSpawnTimeInterval;
	public float MaxSpawnTimeInterval;
	public GameObject[] BaseObjects;

	private float counter;
	private float _spawnTime;
	private Pool Pool;

	// Use this for initialization
	void Start () {
		Pool = new Pool(BaseObjects);
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
		GameObject obj = Pool.InstantiatePoolObject(Random.Range(0, (BaseObjects.Length)));
		Vector3 spawnPosition = new Vector3 (this.transform.position.x, Random.Range(VerticalAxisSpawnRange, -VerticalAxisSpawnRange));
		obj.transform.position = spawnPosition;
		obj.transform.SetParent(this.transform);
	}
}
