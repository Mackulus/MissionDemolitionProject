using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	private bool collisionHasHappened;

	private void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.name != "Ground" && collision.collider.name != "CastleGround"
			&& collision.collider.name != "Mario" && collision.collider.tag != "Dummy Projectile" 
			&& collision.collider.tag != "Projectile")
		{
			this.collisionHasHappened = true;
			MissionDemolition.PlaySound(1);
		}
	}

	void Start()
	{
		collisionHasHappened = false;
	}

	void Update()
	{
		print("Collision has happened = " + collisionHasHappened);
		print("Sleeping = " + this.GetComponent<Rigidbody>().IsSleeping());
		if (this.GetComponent<Rigidbody>().IsSleeping() && collisionHasHappened == true)
		{
			print("true");
			DestroyObject(this);
		}
		else
		{
			print("false");
		}
	}
}
