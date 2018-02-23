using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {
	public void Quit() {
		//This only works in a built game, but it works
		Application.Quit();
	}
}