﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
    {
		print("Found it");
        if (collision.collider.CompareTag("Projectile"))
        {
			Rigidbody projectileRB = collision.collider.GetComponent<Rigidbody>();
			if (Mathf.Abs(projectileRB.velocity.x) >= 15 || 
				Mathf.Abs(projectileRB.velocity.y) >= 15 || 
				Mathf.Abs(projectileRB.velocity.z) >= 15)
			{
				this.gameObject.SetActive(false);
			}
        }
    }
}
