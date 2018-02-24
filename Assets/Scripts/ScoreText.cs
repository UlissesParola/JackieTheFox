using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	private int _difficultRate;
	private int _score;
	private Text _scoreText;
	// Use this for initialization
	void Start ()
	{
		_difficultRate = 1;
		_scoreText = GetComponent<Text>();
	}
	
	public void SetScore(int points)
	{
		_score += points;
		_scoreText.text = _score.ToString();

		if (_score >= _difficultRate * 100)
		{
			Time.timeScale += 0.3f;
			_difficultRate++;
		}
	}

	public int GetScore()
	{
		return _score;
	}
}
