using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAddPoints : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Projectile") || collision.collider.CompareTag("Goomba") || collision.collider.CompareTag("CanHurtEnemy"))
		{
			MissionDemolition.PointsGained(1);
			Invoke("Deactivate", 2f);
		}
	}

	public void Deactivate()
	{
		Destroy(this.gameObject);
	}
}
