using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillGenerator : MonoBehaviour {

	public GameObject grassPatch;
	public GameObject grassParent;

	private const int lengthOfHills = 400;
	private const int maxHeight = 8;
	private const float scaleSize = 0.5f;
	private Vector3 startVector = new Vector3(-50, -9, 200);
	void Start () {
		GenerateHills();
		RemoveHills();
	}
	
	private void GenerateHills()
	{
		Vector3 positionToAdd = startVector;
		for (int height = 0; height < maxHeight; height++)
		{
			for (int i = 0; i < lengthOfHills; i++)
			{
				if (positionToAdd.x < 25 || positionToAdd.x > 40) 
				{
					GameObject grass = Instantiate<GameObject>(grassPatch);
					grass.transform.position = positionToAdd;
					grass.name = getObjName(positionToAdd);
					grass.transform.localScale.Set(scaleSize, scaleSize, scaleSize);
					grass.transform.SetParent(grassParent.transform);
				}
				positionToAdd.x++;
			}
			positionToAdd.x = startVector.x;
			positionToAdd.y++;
		}
	}

	private void RemoveHills()
	{
		Vector3 positionToRemove = startVector;
		float startX = positionToRemove.x;
		float maxRange = 40f;
		for (int height = 0; height < maxHeight; height++)
		{
			getObjName(positionToRemove);
			for (int i = 0; i < lengthOfHills; i++)
			{
				if (positionToRemove.x < 25 || positionToRemove.x > 40) 
				{
					GameObject go = GameObject.Find(getObjName(positionToRemove));
					Vector3 posToCheck = go.transform.position;
					posToCheck.y -= 1;
					string name = getObjName(posToCheck);
					GameObject g = GameObject.Find(name);
					if (g != null)
					{
						float rand = Random.Range(1,maxRange);
						if (rand < 5)
						{
							go.SetActive(false);	
						}
					}
					else if (posToCheck.y >= -9)
						go.SetActive(false);
				}
				positionToRemove.x++;
			}
			positionToRemove.x = startX;
			maxRange -= Mathf.Sqrt(maxRange);
			positionToRemove.y++;
		}
	}

	private string getObjName(Vector3 nameToConvert)
	{
		return nameToConvert.x.ToString() + ", " + nameToConvert.y.ToString();
	}
}
