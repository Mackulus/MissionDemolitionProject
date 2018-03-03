using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollision : MonoBehaviour {

    public GameObject projprefab;

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            ShowProjectilesLeft.AddBall(projprefab);
			GameObject.Find("Flagpole(Clone)").SetActive(false);
        }
    }
}
