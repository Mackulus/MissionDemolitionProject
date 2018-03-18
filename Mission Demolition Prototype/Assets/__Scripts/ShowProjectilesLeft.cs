using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShowProjectilesLeft : MonoBehaviour {

	[Header("Set in Inspector")]
	public int shotsForThisLevel;
	public GameObject projectilePrefab1;
	public GameObject projectilePrefab2;
	public Vector3 startLoc;

	void Start () {
		for (int i = 0; i < shotsForThisLevel; i++)
		{
			GameObject projectile = Instantiate(projectilePrefab1);
			projectile.transform.position = startLoc;
			projectile.name = "Projectile " + Convert.ToString(i);
			projectile.tag = "Dummy Projectile";
			startLoc.x -= 2;
		}	
	}

	static public void AddBall(GameObject projectilePrefabToAdd)
	{
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Dummy Projectile");
		Vector3 spotToAdd = projectiles[0].transform.position;
		foreach(GameObject go in projectiles)
		{
			if (go.transform.position.x < spotToAdd.x)
			{
				spotToAdd = go.transform.position;
			}
			//Vector3 pos = go.transform.position;
			//pos.x += 2;
			//go.transform.position = pos;
		}
		spotToAdd.x -= 2;
		GameObject newProj = Instantiate<GameObject>(projectilePrefabToAdd);
		newProj.transform.position = spotToAdd;
		newProj.tag = "Dummy Projectile";
	}

	static public void AddRewardBall(GameObject projectilePrefab)
	{
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Dummy Projectile");
		Vector3 spotToAdd = projectiles[0].transform.position;
		GameObject prefabToSend = projectiles[0];
		DestroyObject(projectiles[0]);
		GameObject firstProj = Instantiate<GameObject>(projectilePrefab);
		firstProj.transform.position = spotToAdd;
		firstProj.tag = "Dummy Projectile";
		AddBall(prefabToSend);
	}

	static public GameObject GetClosestBall(bool isDestroying)
	{
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Dummy Projectile");
		if (projectiles.Length == 0)
			return null;
		GameObject closest = projectiles[0];
		foreach(GameObject go in projectiles)
		{
			if (go.transform.position.x > closest.transform.position.x)
			{
				closest = go;
			}
			if (isDestroying)
			{
				Vector3 pos = go.transform.position;
				pos.x += 2;
				go.transform.position = pos;
			}
		}
		if (isDestroying) { closest.gameObject.SetActive(false); }
		return closest;
	}

	static public GameObject GetClosestPrefab()
	{
		GameObject go = GetClosestBall(false);
		return PrefabUtility.FindPrefabRoot(go);
	}
}
