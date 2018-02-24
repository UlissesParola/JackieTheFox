using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour {
	public Vector2 Velocity;

	private Rigidbody2D _rigidbody2D;
	// Use this for initialization
	void Start ()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		_rigidbody2D.velocity = Velocity;
	}
}
