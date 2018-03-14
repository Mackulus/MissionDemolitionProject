using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowserGoal : MonoBehaviour {

	//A static field accessible by code anywhere
	static public bool goalMet = false;

	private bool hit = false;

	void OnCollisionEnter(Collision other)
	{
		//When the trigger is hit by something
		//Check to see if it's a projectile
		if (other.gameObject.tag == "Projectile" && hit == false)
		{
			hit = true;
			MissionDemolition.PointsGained(10);
			Goal.goalMet = true;
			ChangeMaterial();
		}
	}

	private void ChangeMaterial()
	{
		//Also set the alpha of the color to higher opacity
		Material mat = GetComponent<Renderer>().material;
		Color c = mat.color;
		c.a = 1;
		mat.color = c;
	}
}