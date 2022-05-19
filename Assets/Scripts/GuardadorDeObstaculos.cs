using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorDeObstaculos : MonoBehaviour
{
	private ObjectPool _poolDeObstaculos;
	// Use this for initialization
	void Start () {
		_poolDeObstaculos = GameObject.Find("PoolDeObstaculos").GetComponent<ObjectPool>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		string nome = other.name.Remove(other.name.IndexOf("("));
		_poolDeObstaculos.RetainObject(other.gameObject, nome);
	}
}
