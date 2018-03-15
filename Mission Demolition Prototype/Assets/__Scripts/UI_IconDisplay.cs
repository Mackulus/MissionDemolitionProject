using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IconDisplay : MonoBehaviour {

	public int goalCount;
	public Sprite emptyIcon;
	public Sprite fullIcon;
	private Image[] icons;
	void Start () {
		icons = gameObject.GetComponentsInChildren<Image>();
		for (int i = 0; i < icons.Length; i++)
		{
			if (i >= goalCount)
			{
				icons[i].gameObject.SetActive(false);
			}
		}
		// sprites are assigned in opposite order of expected (right to left)
	}

	public void UpdateIconDisplay()
	{
		for (int i = 0; i < icons.Length; i++)
		{
			print(i);
			print(icons[i].sprite);
			print(emptyIcon);
			print(icons[i].sprite == emptyIcon);
			if (icons[i].sprite == emptyIcon)
			{
				icons[i].sprite = fullIcon;
				print(fullIcon);
				return;
			}
		}
	}
}
