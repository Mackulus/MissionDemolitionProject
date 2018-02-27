using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAddPoints : MonoBehaviour {

	private bool hit = false;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Projectile") && hit == false)
		{
			print("I've been hit!");
			hit = true;
			MissionDemolition.PointsGained(1);
			Invoke("Deactivate", 2f);
		}
	}

	public void Deactivate()
	{
		this.gameObject.SetActive(false);
	}
}
