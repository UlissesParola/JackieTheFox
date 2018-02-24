using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScoreManager : MonoBehaviour
{
	private const string Score1 = "Score1";
	private const string Score2 = "Score2";
	private const string Score3 = "Score3";
	private const string Score4 = "Score4";
	private const string Score5 = "Score5";
	private const string Score6 = "Score6";
	private const int ScoreQuant = 6;
	private static int _scorePosition;
	private static List<int> _topScores = new List<int>(new int[ScoreQuant]);


	public static void SetScore(int newScore)
	{
		int index = -1;

		for (int i = 0; i < ScoreQuant; i++)
		{
			if (newScore > _topScores[i])
			{
				index = i;
				break;
			}
		}

		if (index >= 0)
		{
			_topScores.Insert(index, newScore);
			_topScores.RemoveAt(ScoreQuant);
			_scorePosition = index;
		}
	}

	public static List<int> GetTopScores()
	{
		return _topScores;
	}

	public static bool IsTopScore(int newScore)
	{
		for (int i = 0; i < ScoreQuant; i++)
		{
			if (newScore > _topScores[i])
			{
				return true;
			}
		}
		return false;
	}

	public static int GetScorePosition()
	{
		return _scorePosition;
	}

	public static void ResetTempValues()
	{
		_scorePosition = -1;
	}

	public static void SaveScores()
	{
		PlayerPrefs.SetInt(Score1, _topScores[0]);
		PlayerPrefs.SetInt(Score2, _topScores[1]);
		PlayerPrefs.SetInt(Score3, _topScores[2]);
		PlayerPrefs.SetInt(Score4, _topScores[3]);
		PlayerPrefs.SetInt(Score5, _topScores[4]);
		PlayerPrefs.SetInt(Score6, _topScores[5]);
	}

	public static void LoadScores()
	{
		_topScores[0] = PlayerPrefs.GetInt(Score1, 0);
		_topScores[1] = PlayerPrefs.GetInt(Score2, 0);
		_topScores[2] = PlayerPrefs.GetInt(Score3, 0);
		_topScores[3] = PlayerPrefs.GetInt(Score4, 0);
		_topScores[4] = PlayerPrefs.GetInt(Score5, 0);
		_topScores[5] = PlayerPrefs.GetInt(Score6, 0);
	}
}
