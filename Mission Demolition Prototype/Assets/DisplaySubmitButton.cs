using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySubmitButton : MonoBehaviour {

	public GameObject submitButton;

	public void DisplayButton(string value)
	{
		if (value != "")
		{
			submitButton.SetActive(true);
		}
		else
		{
			submitButton.SetActive(false);
		}
	}
}
