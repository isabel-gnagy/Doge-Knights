using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    public ExampleCharacterController controller;
    public HealthManager playerHealth;
    public float damageAmount = 2f;
    void Start()
    {

    }


    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Damages Player");
            playerHealth = collision.gameObject.GetComponent<HealthManager>();
            playerHealth.TakeDamage(damageAmount);
            controller = collision.gameObject.GetComponent<ExampleCharacterController>();
            controller._timeSinceJumpRequested = Mathf.Infinity;
            controller._jumpRequested = true;
        }

    }
}
