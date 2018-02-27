using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButtonHandler : MonoBehaviour {

	public InputField input;

	public void submitName()
	{
		MissionDemolition.SetNameEntered(input.text);
	}
}
