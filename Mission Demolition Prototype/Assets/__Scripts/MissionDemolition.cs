using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameMode
{
	idle,
	playing,
	levelEnd
}

public class MissionDemolition : MonoBehaviour {
	static private MissionDemolition S; // a private singleton
	static private int totalScore = 0;

	[Header("Set in Inspector")]
	//public Text uitLevel; //The UIText_Level text
	public Button uiRestartButton; //The UIButton_Restart
	public Text uitScore;//The UIT_Score text
	public Text uitShots; //The UIText_Shots text
	public Text uitButton; //The Text on UIButton_View
	public GameObject highScorePanel; //The Panel that displays if a score makes it on the highscore list
	public Vector3 castlePos; //The place to put castles
	public GameObject castlePrefab; //A reference to the castle prefab
	//public CastleGeneration castleGeneration; //A reference to the background castle generator

	[Header("Set Dynamically")]
	private GameObject castle; //The current castle
	private GameMode mode = GameMode.idle;
	private int level; //The current level
	private int shotsTaken; //shots taken
	private string showing = "Show Slingshot"; //FollowCam mode
	private bool nameEntered;
	private int highScorePosition;

	// Use this for initialization
	void Start () 
	{
		S = this; //Define the singleton
		uiRestartButton.onClick.AddListener(RestartGame);

		level = Convert.ToInt16(SceneManager.GetActiveScene().name.Substring(7));
		StartLevel();
	}
	
	void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void StartLevel ()
	{
		//castleGeneration.PlaceCastle();
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
		castle = Instantiate<GameObject>(castlePrefab);
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
		uitShots.text = "Shots Taken: " + shotsTaken;
		uitScore.text = "Score: " + totalScore;

	}

	void Update ()
	{
		UpdateGUI();

		//Check for level end
		if ((mode == GameMode.playing) && Goal.goalMet)
		{
			//Change mode to stop checking for level end
			mode = GameMode.levelEnd;
			GameObject projLeft = GameObject.FindGameObjectWithTag("Projectile");
			if (projLeft != null)
			{
				Destroy(projLeft);
			}
			if (!PlayerPrefs.HasKey("Level " + (level+1) +"complete"))
			{
				PlayerPrefs.SetString("Level " + (level+1) +"complete", "true");
			}
			PlaySound(0);
			//Zoom out
			SwitchView("Show Both");
			//Start the next level in 7.5 seconds
			Invoke("NextLevel", 7f);
		}
			
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			highScorePosition = HighScoreController.CheckForHighScore(totalScore);
			if (highScorePosition < 10)
			{
				highScorePanel.SetActive(true);
				StartCoroutine(WaitForName());
			}
			else
			{
				SceneManager.LoadScene("_Scene_MainMenu");
			}
		}
	}

	IEnumerator WaitForName()
	{
		yield return new WaitUntil(() => nameEntered == true);
		SceneManager.LoadScene("_Scene_MainMenu");
	}

	void NextLevel ()
	{
		SceneManager.LoadScene("_Scene_" + Convert.ToString(level + 1));
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
			break;

		case "Show Castle":
			FollowCam.POI = S.castle;
			uitButton.text = "Show Both";
			break;

		case "Show Both":
			FollowCam.POI = GameObject.Find("ViewBoth");
			uitButton.text = "Show Slingshot";
			break;
		}
	}

	//Static method that allows code anywhere to increment shotsTaken
	public static void ShotFired()
	{
		S.shotsTaken++;
	}

	public static void ProjectileGained()
	{
		S.shotsTaken--;
	}

	public static void PointsGained(int points)
	{
		totalScore += points;
	}

	public static void SetNameEntered(string name)
	{
		HighScoreController.NewScore(name, S.highScorePosition);
		S.nameEntered = true;
	}

	public static void ExplosionView()
	{
		S.SwitchView("Show Both");
	}

	public static void PlaySound(int soundNumber)
	{
		print("here");
		S.GetComponentsInParent<AudioSource>()[soundNumber].Play();
	}
}
