using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
	public Text[] ScoresTexts;

	// Use this for initialization
	void Start()
	{
		List<int> scores = TopScoreManager.GetTopScores();
		for (int i = 0; i < 6; i++)
		{
			ScoresTexts[i].text = scores[i].ToString();
		}

		if (TopScoreManager.GetScorePosition() >= 0 && !SceneManager.GetActiveScene().name.Equals("Main Menu"))
		{
			ScoresTexts[TopScoreManager.GetScorePosition()].color = Color.yellow;
		}

		TopScoreManager.ResetTempValues();
	}

}
