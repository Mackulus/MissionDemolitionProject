using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour {

	public Sprite brick;
	public Sprite brickLight;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Projectile"))
		{
			
			if (this.GetComponent<SpriteRenderer>().sprite == brick)
			{
				this.GetComponent<SpriteRenderer>().sprite = brickLight;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}
}
