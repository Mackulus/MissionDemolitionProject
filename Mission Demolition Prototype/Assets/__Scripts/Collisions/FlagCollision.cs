using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollision : MonoBehaviour {

    public GameObject projprefab;

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            ShowProjectilesLeft.AddRewardBall(projprefab);
			GameObject.Find("Flagpole(Clone)").SetActive(false);
        }
    }
}
