using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private float damageAmount = 1f;
    private GameObject Player;
    private ExampleCharacterController controller;
    private HealthManager playerHealth;

    void Awake()
    {
        Player = GameObject.Find("DogPolyart");
        controller = Player.GetComponent<ExampleCharacterController>();
        playerHealth = Player.GetComponent<HealthManager>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = Player.transform.position - gameObject.transform.position;
            StartCoroutine(knockBackCoroutine(direction));
            DealDamage();
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = Player.transform.position - gameObject.transform.position;
            StartCoroutine(knockBackCoroutine(direction));
            DealDamage();
        }
    }

    IEnumerator knockBackCoroutine(Vector3 direction)
    {
        controller.jumpCount = 0;
        controller._jumpRequested = true;
        controller.AddVelocity(direction*13f);
        yield return new WaitForSeconds(0.5f);
    }

    public void DealDamage()
    {
        
        Debug.Log(" Player Damaged by " + damageAmount);
        playerHealth.TakeDamage(damageAmount);
        Debug.Log("Player Health = " + playerHealth.currentHealth);
    }


}