using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
			Rigidbody projectileRB = collision.collider.GetComponent<Rigidbody>();
			if (projectileRB.velocity.x >= 15 || projectileRB.velocity.y >= 15 || projectileRB.velocity.z >= 15)
			{
				this.gameObject.SetActive(false);
			}
        }
    }
}
