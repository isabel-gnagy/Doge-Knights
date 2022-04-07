using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// https://answers.unity.com/questions/398607/spawn-after-every-5-seconds.html
/// </summary>
/// 
public class RockFalling : MonoBehaviour
{

    public GameObject rock;
    public float spawnTime = 5f;
    public float lifetime = 5f;
    private Vector3 spawnLocation;
    private Quaternion rockRotation;


    void Start()
    {

        rockRotation = rock.transform.rotation;
        InvokeRepeating("SpawnRock", spawnTime, spawnTime);

    }


    void Update()
    {

    }

    public void SpawnRock()
    {

        spawnLocation = transform.position;

        var newRock = GameObject.Instantiate(rock, spawnLocation, rockRotation);
        Destroy(newRock, lifetime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player DeD");
        }
    }
}
