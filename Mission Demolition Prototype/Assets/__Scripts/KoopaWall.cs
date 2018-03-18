using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaWall : MonoBehaviour {

    private Vector3 velocity;
    private void OnCollisionEnter(Collision collision)
    {
        velocity = collision.collider.GetComponent<Rigidbody>().velocity;
        print(collision.collider.name);
        if (collision.collider.name == "WallDestroyer")
        {
            gameObject.SetActive(false);
            collision.collider.GetComponent<Rigidbody>().velocity = velocity;
        }
    }
}
