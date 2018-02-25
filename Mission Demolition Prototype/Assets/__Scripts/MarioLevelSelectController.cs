using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MarioLevelSelectController : MonoBehaviour {

	public GameObject mario;

	private bool clicked = false;

	public void OnMouseEnter()
	{
		print("Here");
		mario.SetActive(true);
	}

	public void OnMouseExit()
	{
		if (!clicked)
		{
			print("There");
			mario.SetActive(false);
		}
	}

	public void OnMouseUp()
	{
		clicked = true;
		Animator anim = mario.GetComponent<Animator>();
		anim.Play("Mario Down The Tube");
		mario.GetComponent<AudioSource>().Play();
		Invoke("CallLoadScene", 1f);
	}

	public void CallLoadScene()
	{
		string level = GetComponentInChildren<Text>().text;
		int levelNumber = Int32.Parse(level) - 1;
		SceneManager.LoadScene("_Scene_"+levelNumber.ToString());
	}
}
