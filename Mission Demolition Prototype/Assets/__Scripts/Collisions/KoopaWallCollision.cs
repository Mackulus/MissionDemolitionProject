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
            if (other.GetComponent<Explosion>())
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
