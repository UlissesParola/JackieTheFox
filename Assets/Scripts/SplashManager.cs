using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
	private LevelManager _levelManager;
	// Use this for initialization
	void Start ()
	{
		TopScoreManager.LoadScores();
		_levelManager = FindObjectOfType<LevelManager>();
		Invoke("LoadMainMenu", 3);
	}

	private void LoadMainMenu()
	{
		_levelManager.LoadNextScene();
	}
}
