﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
	idle,
	playing,
	levelEnd
}

public class MissionDemolition : MonoBehaviour {
	static private MissionDemolition S; // a private singleton

	[Header("Set in Inspector")]
	//public Text uitLevel; //The UIText_Level text
	public Button uiRestartButton; //The UIButton_Restart
	public Text uitShots; //The UIText_Shots text
	public Text uitButton; //The Text on UIButton_View
	public Vector3 castlePos; //The place to put castles
	public GameObject[] castles; //An array of the castles
	public CastleGeneration castleGeneration; //A reference to the background castle generator

	[Header("Set Dynamically")]
	public int level; //The current level
	public int levelMax; //The number of levels
	public int shotsTaken;
	public GameObject castle; //The current castle
	public GameMode mode = GameMode.idle;
	public string showing = "Show Slingshot"; //FollowCam mode

	private MeshRenderer[] Mario;
	// Use this for initialization
	void Start () 
	{
		S = this; //Define the singleton
		uiRestartButton.onClick.AddListener(StartLevel);
		Mario = GameObject.Find("Mario").GetComponentsInChildren<MeshRenderer>();
		
		level = 0;
		levelMax = castles.Length;
		StartLevel();
	}
	
	void StartLevel ()
	{
		castleGeneration.PlaceCastle();
		//Get rid of the old castle if one exists
		if (castle != null)
		{
			Destroy(castle);
		}

		//Destroy old projectiles if they exist
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
		foreach (GameObject pTemp in gos)
		{
			Destroy(pTemp);
		}

		//Instantiate the new castle
		castle = Instantiate<GameObject>(castles[level]);
		castle.transform.position = castlePos;
		shotsTaken = 0;

		//Reset the camera
		SwitchView("Show Both");
		ProjectileLine.S.Clear();

		//Reset the goal
		Goal.goalMet = false;

		UpdateGUI();

		mode = GameMode.playing;
	}

	void UpdateGUI () 
	{
		//Show the data in the GUITexts
		//uitLevel.text = "Level: "+(level+1)+" of "+levelMax;
		uitShots.text = "Shots Taken: "+shotsTaken;
	}

	void Update ()
	{
		UpdateGUI();

		//Check for level end
		if ((mode == GameMode.playing) && Goal.goalMet)
		{
			//Change mode to stop checking for level end
			mode = GameMode.levelEnd;
			//Zoom out
			SwitchView("Show Both");
			//Start the next level in 2 seconds
			Invoke("NextLevel", 2f);
		}
	}

	void NextLevel ()
	{
		level++;
		if (level == levelMax)
		{
			level = 0;
		}
		StartLevel();
	}

	public void SwitchView (string eView = "")
	{
		if (eView == "")
		{
			eView = uitButton.text;
		}
		showing = eView;
		switch (showing)
		{
		case "Show Slingshot":
			FollowCam.POI = null;
			uitButton.text = "Show Castle";
			// set back3 active
			break;

		case "Show Castle":
			FollowCam.POI = S.castle;
			uitButton.text = "Show Both";
			// set back3 active
			break;

		case "Show Both":
			FollowCam.POI = GameObject.Find("ViewBoth");
			uitButton.text = "Show Slingshot";
			// iterate through array to set background 1 and 2 active
			break;
		}
	}

	//Static method that allows code anywhere to increment shotsTaken
	public static void ShotFired()
	{
		S.shotsTaken++;
	}
}
