using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollision : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            MissionDemolition.ProjectileGained();
			GameObject.Find("Flagpole(Clone)").SetActive(false);
        }
    }
}
