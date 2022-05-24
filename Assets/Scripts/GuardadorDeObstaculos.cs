using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorDeObstaculos : MonoBehaviour
{
	private Pool _poolDeObstaculos;
	// Use this for initialization
	void Start () {
		_poolDeObstaculos = GameObject.Find("PoolDeObstaculos").GetComponent<Pool>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		string nome = other.name.Remove(other.name.IndexOf("("));
		//_poolDeObstaculos.RetainObject(other.gameObject, nome);
	}
}
