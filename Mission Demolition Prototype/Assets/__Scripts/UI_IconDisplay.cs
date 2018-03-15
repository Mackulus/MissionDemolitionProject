using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IconDisplay : MonoBehaviour {

	public int goalCount;
	public Sprite emptyIcon;
	public Sprite fullIcon;
	private Sprite[] sprites;
	void Start () {
		GameObject[] icons = GameObject.FindGameObjectsWithTag("UI_Icon");
		sprites = new Sprite[icons.Length];
		for (int i = 0; i < icons.Length; i++)
		{
			if (i < goalCount)
			{
				sprites[i] = icons[i].GetComponent<Image>().sprite;
			}
			else
			{
				icons[i].SetActive(false);
			}
		}
		// sprites are assigned in opposite order of expected (right to left)
	}

	private void UpdateIconDisplay()
	{
		for (int i = 0; i < sprites.Length; i++)
		{
			if (sprites[i] == emptyIcon)
			{
				sprites[i] = fullIcon;
				return;
			}
		}
	}
}
