using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public ObjectPool Pool;
	public Vector3 Range;
	public float RepeatTime;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 0 , RepeatTime);
		float width = Camera.main.orthographicSize * Camera.main.aspect;
		transform.position = new Vector3(width + 3, transform.position.y);
	}
	
	private void Spawn()
	{
		GameObject enemyPrefab = Pool.InstantiatePoolObject(Random.Range(0, (Pool.PoolSize -1)));

		Vector3 spawnPosition = Vector3.Lerp(Range, -Range, Random.value) + this.transform.position;

		Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, this.transform);
	}
}
