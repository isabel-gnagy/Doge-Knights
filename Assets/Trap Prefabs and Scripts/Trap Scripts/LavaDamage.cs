using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    private float damageAmount = 3f;
    private HealthManager playerHealth;
    void Start()
    {
    }


    void Update()
    {

    }

    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player got cooked lol");
            playerHealth = collision.gameObject.GetComponent<HealthManager>();
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Player Health = " + playerHealth.currentHealth);
        }

    }
}
