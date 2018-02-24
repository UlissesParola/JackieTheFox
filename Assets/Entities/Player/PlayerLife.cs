using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
	public int Lives;
	public Text LifeText;

	private LevelManager _levelManager;
	private ScoreText _scoreText;

	private void Start()
	{
		_levelManager = GameObject.FindObjectOfType<LevelManager>();
		_scoreText = FindObjectOfType<ScoreText>();
		LifeText.text = Lives.ToString();
	}

	public void Hitted()
	{
		Lives--;
		if (Lives < 0)
		{
			if (TopScoreManager.IsTopScore(_scoreText.GetScore()))
			{
				Time.timeScale = 1;
				TopScoreManager.SetScore(_scoreText.GetScore());
				TopScoreManager.SaveScores();
				_levelManager.LoadLevel("TopScore");
			}
			else
			{
				Time.timeScale = 1;
				_levelManager.LoadLevel("Lose");
			}
		}
		else
		{
			LifeText.text = Lives.ToString();
		}
	}
}
