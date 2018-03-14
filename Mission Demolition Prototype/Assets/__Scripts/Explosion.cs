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
        print(collision.collider.name);
        if (collision.collider.name != "Ground" && collision.collider.name != "CastleGround"
            && collision.collider.name != "Mario" && collision.collider.tag != "Dummy Projectile" 
            && collision.collider.tag != "Projectile")
        {
            print("collision");
            bomb = this.gameObject;
            //bomb.GetComponentInParent<AudioSource>().Play();
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            print(colliders);
            foreach (Collider hit in colliders)
            {
                print(hit);
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                print(rb);
                if (rb != null)
                {
                    print("explode");
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Impulse);
                }
            }

            bomb.SetActive(false);
        }
	}
}