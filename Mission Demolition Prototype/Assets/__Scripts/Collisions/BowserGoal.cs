using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowserGoal : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		//When the trigger is hit by something
		//Check to see if it's a projectile
		if (other.gameObject.tag == "Projectile")
		{

			if (SceneManager.GetActiveScene().name == "_Scene_0")
			{
				print("bowser is a goal");
				Goal.goalsReached++;
				if (Goal.goalsReached == 3)
				{
					//If so, set goalMet to true
					Goal.goalMet = true;
				}
			}
			else 
			{
				Goal.goalMet = true;
			}
		}
	}
}