using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
	//A static field accessible by code anywhere
	static public bool goalMet = false;
	static public int goalsReached = 0;

	void OnTriggerEnter(Collider other)
	{
		//When the trigger is hit by something
		//Check to see if it's a projectile
		if (other.gameObject.tag == "Projectile")
		{
			if (SceneManager.GetActiveScene().name == "_Scene_0")
			{
				Goal.goalsReached++;
				if (Goal.goalsReached == 3)
				{
					//If so, set goalMet to true
					Goal.goalMet = true;
				}
				ChangeMaterial();
			}
			else {
				Goal.goalMet = true;
				ChangeMaterial();
			}
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
