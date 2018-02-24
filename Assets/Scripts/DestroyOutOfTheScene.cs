using UnityEngine;

public class DestroyOutOfTheScene : MonoBehaviour
{
	private float _width;

	private void Start()
	{
		_width = Camera.main.orthographicSize * Camera.main.aspect;
		Debug.Log(_width);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < (-_width - 3))
		{
			Debug.Log(_width);
			Destroy(this.gameObject);
		}
	}
}
