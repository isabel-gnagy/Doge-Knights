using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerTurret : MonoBehaviour
{

    //public Transform TurretPivot;

    public Transform PlayerPosition;
    public bool playerInRange = false;
    public float spawnTime = 1f;
    private float spawnInterval = 1f;

    public Transform SpawnPoint;
    public GameObject Projectile;
    private Rigidbody projectileRB;

    void Start()
    {
        projectileRB = GetComponent<Rigidbody>();
        InvokeRepeating("FireAtPlayer", 1f, spawnInterval);
    }


    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        if (playerInRange==true)
        {
            Vector3 relativePos = PlayerPosition.position - transform.position;
            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100f);

        }
    }

    
    public void FireAtPlayer()
    {
        if (playerInRange==true)
        {
            SpawnProjectiles();
        }
    }

    public void SpawnProjectiles()
    {
        GameObject newProjectile = GameObject.Instantiate(Projectile, SpawnPoint.position, SpawnPoint.rotation);

        Destroy(newProjectile, 5f);

    }


}
