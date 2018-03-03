using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagpoleCollision : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
			GameObject.Find("Flagpole(Clone)").SetActive(false);
        }
    }
}
