using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BowserGoal : MonoBehaviour {

	//A static field accessible by code anywhere
	//static public bool goalMet = false;

	private bool hit = false;
	private Image[] icons;

	void Start()
	{
		Invoke("getIcons", 0.1f);
	}

	void OnCollisionEnter(Collision other)
	{
		//When the trigger is hit by something
		//Check to see if it's a projectile
		if (other.gameObject.tag == "Projectile" && hit == false)
		{
			GameObject.Find("Icons").GetComponent<UI_IconDisplay>().UpdateIconDisplay();
			MissionDemolition.PointsGained(10);
			Invoke("RemoveBowser", 1.5f);
			if (SceneManager.GetActiveScene().name == "_Scene_1")
			{
				if (isGameOver())
				{
					Goal.goalMet = true;
				}
			}
			else
			{
				if (isGameOver())
					Goal.goalMet = true;
			}
		}
	}

	private void getIcons()
	{
		icons = GameObject.Find("Icons").GetComponent<UI_IconDisplay>().GetImages();
	}

	private void RemoveBowser()
	{
		gameObject.SetActive(false);
	}

	private bool isGameOver()
	{
		bool result = true;
		foreach (Image icon in icons)
		{
			if (icon.sprite.name == "bowser_icon2")
				result = false;
		}
		return result;
	}
}