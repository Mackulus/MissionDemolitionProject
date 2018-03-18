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
        if (collision.collider.tag == "Projectile")
        {
            Invoke("createNewDestroyer", 1f);
        }
    }

    private void createNewDestroyer()
    {
        Instantiate(wallDestroyer).transform.position = startPos;
    }
}
