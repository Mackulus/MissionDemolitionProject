using UnityEngine;
using System.Collections;

// Applies an explosion force to all nearby rigidbodies
public class Explosion : MonoBehaviour
{
	//Explosion code found here https://www.youtube.com/watch?v=XMDfhHyOacM

	private GameObject bomb;
	public float radius = 5.0F;
	public float power = 10.0F;

	private void OnCollisionEnter(Collision collision)
	{
        if (gameObject.transform.position.x >= 70 && collision.collider.name == "Ground")
        {
            MissionDemolition.ExplosionView();
            gameObject.SetActive(false);
        }
        if (collision.collider.name != "Ground" && collision.collider.name != "CastleGround"
            && collision.collider.name != "Mario" && collision.collider.tag != "Dummy Projectile"
			&& collision.collider.tag != "HoldingProjectile" && transform.tag != "Dummy Projectile")
        {
			print(collision.collider.name);
			MissionDemolition.ExplosionView();
            bomb = this.gameObject;
			MissionDemolition.PlaySound(3);
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.tag == "Brick")
                {
                    DestroyObject(hit.gameObject);
                }
                else if (hit.tag == "Finish")
                {
                    hit.GetComponent<BowserGoal>().bowserDeath();
                }
                else
				{
	                Rigidbody rb = hit.GetComponent<Rigidbody>();
	                if (rb != null)
	                {
	                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Impulse);
	                }
				}
            }

            bomb.SetActive(false);
        }
	}
}