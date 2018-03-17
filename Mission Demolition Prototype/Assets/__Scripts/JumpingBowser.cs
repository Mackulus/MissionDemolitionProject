using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBowser : MonoBehaviour {
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update () {
		if (rb.velocity.y == 0)
        {
            Vector3 force;
            if (gameObject.transform.position.x > -45 && gameObject.transform.position.x < -25)
            {
                force = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(0.0f, 15.0f), 0.0f) * 15;
                rb.AddForce(force * rb.mass);
            }
            else if (gameObject.transform.position.x < -45)
            {
                force = new Vector3(Random.Range(-10f, 0f), Random.Range(0.0f, 15.0f), 0.0f) * 15;
                rb.AddForce(force * rb.mass);
            }
            else if (gameObject.transform.position.x > -25)
            {
                force = new Vector3(Random.Range(0f, 10.0f), Random.Range(0.0f, 15.0f), 0.0f) * 15;
                rb.AddForce(force * rb.mass);
            }
        }
	}
}
