using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateHighScorePanel : MonoBehaviour {

	public GameObject parentPanel;
	public GameObject scorePanelPrefab;




	private int highScoreAmount;

	void Start()
	{
		highScoreAmount = HighScoreController.highScoreAmount;
		Vector3 textSize = new Vector3(0.75f,0.75f,1f);
		for (int i = 0; i < highScoreAmount; i++)
		{
			if (PlayerPrefs.HasKey("MarioHighScoreName" + i))
			{
				GameObject newScore = Instantiate(scorePanelPrefab) as GameObject;
				newScore.transform.parent = parentPanel.transform;
				newScore.transform.localPosition = Vector3.zero;
				newScore.transform.localScale = Vector3.one;
				Text[] textComponents = newScore.GetComponentsInChildren<Text>();
				textComponents[0].text = PlayerPrefs.GetString("MarioHighScoreName"+i);
				textComponents[0].transform.localScale = textSize;
				textComponents[1].text = (PlayerPrefs.GetInt("MarioHighScore"+i)).ToString();
				textComponents[1].transform.localScale = textSize;
			}
		}
	}
}
