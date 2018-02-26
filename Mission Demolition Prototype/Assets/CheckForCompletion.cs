using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckForCompletion : MonoBehaviour {

	public GameObject flag;

	private string level;
	private int levelNum;

	// Use this for initialization
	void Start () 
	{
		print("Checking");
		levelNum = Int32.Parse(transform.name.Substring(5))-1;
		level = levelNum.ToString();
		if (PlayerPrefs.HasKey("_Scene_"+level+"complete"))
		{
			flag.SetActive(true);
		}
	}

}
