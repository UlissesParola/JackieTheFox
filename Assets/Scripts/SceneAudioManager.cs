using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudioManager : MonoBehaviour
{
	public bool Loop;
	private AudioManager _audioManager;
	// Use this for initialization
	void Start ()
	{
		_audioManager = FindObjectOfType<AudioManager>();
		_audioManager.SetActiveSceneIndex(SceneManager.GetActiveScene().buildIndex);
		_audioManager.GetComponent<AudioSource>().loop = Loop;
	}	
}
