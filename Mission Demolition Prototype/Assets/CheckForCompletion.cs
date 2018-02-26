using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckForCompletion : MonoBehaviour {

	public GameObject flag;

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.HasKey(transform.name+"complete"))
		{
			flag.SetActive(true);
		}
	}

}
