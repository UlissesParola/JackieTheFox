using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] Musics;

	private AudioSource _audioSource;
	private int _activeSceneIndex;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		_audioSource = GetComponent<AudioSource>();
	}

	public void SetActiveSceneIndex(int index)
	{
		_activeSceneIndex = index;
		ChangeMusic();
	}

	private void ChangeMusic()
	{
		_audioSource.clip = Musics[_activeSceneIndex - 1];
		_audioSource.Play();
	}
}
