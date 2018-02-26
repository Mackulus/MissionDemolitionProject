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
		int newScore, oldScore, playerPosition;
		string newName, oldName;
		bool playerPositionSet;
		newName = "fake";
		newScore = score;
		playerPosition = 10;
		playerPositionSet = false;

		for (int i = 0; i < highScoreAmount; i++) {
			if (PlayerPrefs.HasKey("MarioHighScoreName" + i)) {
				oldScore = PlayerPrefs.GetInt("MarioHighScore" + i);
				if (oldScore < newScore) {
					if (!playerPositionSet && newScore == score)
					{
						playerPosition = i;
						playerPositionSet = true;
					}
					oldName = PlayerPrefs.GetString("MarioHighScoreName" + i);
					PlayerPrefs.SetString("MarioHighScoreName" + i, newName);
					PlayerPrefs.SetInt("MarioHighScore" + i, newScore);
					newName = oldName;
					newScore = oldScore;
				}
			}
			else {
				if (!playerPositionSet && newScore == score)
				{
					playerPosition = i;
					playerPositionSet = true;
				}
				PlayerPrefs.SetString("MarioHighScoreName" + i, newName);
				PlayerPrefs.SetInt("MarioHighScore" + i, newScore);
				i = highScoreAmount;
			}
		}

		return playerPosition;
	}

	public static void NewScore(string name, int position) 
	{
		
		print("Setting name to " + name + "at MarioHighScoreName" + position);
		PlayerPrefs.SetString("MarioHighScoreName" + position, name);
	}
}