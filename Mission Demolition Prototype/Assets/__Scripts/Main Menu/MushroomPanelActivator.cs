using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomPanelActivator : MonoBehaviour {

	public GameObject mushroomPanel;

	public void OnMouseEnter()
	{
		mushroomPanel.SetActive(true);
	}

	public void OnMouseExit()
	{
		mushroomPanel.SetActive(false);
	}
}
