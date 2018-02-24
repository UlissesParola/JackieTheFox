using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] EnemiesPrefabs;
	public Vector3 Range;
	public float RepeatTime;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 0 , RepeatTime);
	}
	
	private void Spawn()
	{
		int prefabindex = Random.Range(0, EnemiesPrefabs.Length);
		GameObject enemyPrefab = EnemiesPrefabs[prefabindex];

		Vector3 spawnPosition = Vector3.Lerp(Range, -Range, Random.value) + this.transform.position;

		Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, this.transform);
	}
}
