using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAnotherWallDestroyer : MonoBehaviour {

    public GameObject wallDestroyer;
    private Vector3 startPos;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(startPos, .1f);

        if (collision.collider.tag == "Projectile" && (colliders.Length == 0 || 
            (colliders.Length == 1 && colliders[0].tag == "CanHurtEnemy")))
        {
            Invoke("createNewDestroyer", 1f);
        }
        else if (collision.collider.tag == "Projectile")
        {
            //print(colliders);
            foreach (Collider c in colliders)
            {
                print(c);
            }
        }
        else
        {
            print(colliders);
        }
    }

    private void createNewDestroyer()
    {
        GameObject newWallDestroyer = Instantiate(wallDestroyer);
        newWallDestroyer.transform.position = startPos;
    }
}
