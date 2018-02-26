using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

	public static int highScoreAmount = 10;

	//High Score Board code found here
	//https://answers.unity.com/questions/20773/how-do-i-make-a-highscores-board.html

	public static int CheckForHighScore(int score)
	{
		int newScore, oldScore;
		string newName, oldName;
		newName = "fake";
		newScore = score;

		for (int i = 0; i < highScoreAmount; i++) {
			if (PlayerPrefs.HasKey("HighScoreName" + i)) {
				oldScore = PlayerPrefs.GetInt("HighScore" + i);
				if (oldScore < newScore) {
					oldName = PlayerPrefs.GetString("HighScoreName" + i);
					PlayerPrefs.SetString("HighScoreName" + i, newName);
					PlayerPrefs.SetInt("HighScore" + i, newScore);
					newName = oldName;
					newScore = oldScore;
				}
			}
			else {
				PlayerPrefs.SetString("HighScoreName" + i, newName);
				PlayerPrefs.SetInt("HighScore" + i, newScore);
			}
		}
	}

	public static void NewScore(string name, int score) 
	{
		PlayerPrefs.SetString("MarioHighScoreName" + score, name);
	}
}