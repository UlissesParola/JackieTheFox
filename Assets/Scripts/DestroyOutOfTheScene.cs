using UnityEngine;

public class DestroyOutOfTheScene : MonoBehaviour
{
	private float _width;

	private void Start()
	{
		_width = Camera.main.orthographicSize * Camera.main.aspect;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < (-_width - 3))
		{
			Destroy(this.gameObject);
		}
	}
}
