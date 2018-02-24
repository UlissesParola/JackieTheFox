using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSaverManager : MonoBehaviour
{
	public float ScreenSaverTime;
	public GameObject MainCanvas;
	public GameObject ScreenSaverCanvas;

	private float _timer;
	private bool _screenSaverActive;
	
	// Update is called once per frame
	void Update ()
	{
		_timer += Time.deltaTime;

		if (Input.GetMouseButton(0))
		{
			_timer = 0f;
			if (_screenSaverActive)
			{
				ScreenSaverCanvas.SetActive(false);
				MainCanvas.SetActive(true);
			}
		}

		if (_timer > ScreenSaverTime)
		{
			_screenSaverActive = true;
			ScreenSaverCanvas.SetActive(true);
			MainCanvas.SetActive(false);
		}
	}
}
