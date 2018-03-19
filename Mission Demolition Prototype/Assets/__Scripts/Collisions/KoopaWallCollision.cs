using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaWallCollision : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "WallDestroyer" || other.name == "WallDestroyer(Clone)")
        {
            gameObject.SetActive(false);
        }
        else if (other.tag == "Projectile")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
