using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowProjectilesLeft : MonoBehaviour {

	[Header("Set in Inspector")]
	public int shotsForThisLevel;
	public GameObject projectilePrefab1;
	public GameObject projectilePrefab2;
	public Vector3 startLoc;

	void Start () {
		for (int i = MissionDemolition.GetShots(); i < shotsForThisLevel; i++)
		{
			GameObject projectile = Instantiate(projectilePrefab1);
			projectile.transform.position = startLoc;
			startLoc.x -= 3;
		}	
	}
}
