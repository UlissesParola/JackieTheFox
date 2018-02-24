using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreItem : MonoBehaviour
{
	public int ScoreValue;
	public AudioClip GetItemAudioClip;

	private ScoreText _scoretext;

	private void Start()
	{
		_scoretext = GameObject.FindObjectOfType<ScoreText>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.Equals("Player"))
		{
			AudioSource.PlayClipAtPoint(GetItemAudioClip, Camera.main.transform.position);
			_scoretext.SetScore(ScoreValue);
			Destroy(this.gameObject);
		}
	}
}
