using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioInfinito : MonoBehaviour
{
	public Vector3 Velocity;
	public float Distance;

	private Vector3 _startPosition;
	// Use this for initialization
	void Start ()
	{
		_startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Velocity * Time.deltaTime);

		Vector3 actualPosition = transform.position;

		if (Vector3.Distance(actualPosition, _startPosition) >= Distance)
		{
			Vector3 direction = (_startPosition - actualPosition).normalized * Distance;
			transform.Translate(direction);
		}
	}
}
