using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour{

    private float damage = 1f;
    GameObject Player;
    public ExampleCharacterController controller;
    public HealthManager playerHealth;

   // public GameObject explosionOnHit;

    void Start(){
        Player = GameObject.Find("DogPolyart");
        controller = Player.GetComponent<ExampleCharacterController>();
        playerHealth = Player.GetComponent<HealthManager>();
    }

    void Update(){
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Vector3 direction = gameObject.transform.position - Player.transform.position;
            StartCoroutine(knockBackCoroutine(Player, direction));
            DealDamage();
            Destroy(gameObject);
        }
       
    }

    IEnumerator knockBackCoroutine(GameObject target, Vector3 direction)
    {
        controller.jumpCount = 0;
        controller._jumpRequested = true;
        controller.AddVelocity(direction * -6f);
        yield return new WaitForSeconds(0.5f);
    }

    public void DealDamage()
    {

        Debug.Log(" Player Damaged by " + damage);
        playerHealth.TakeDamage(damage);
        Debug.Log("Player Health = " + playerHealth.currentHealth);
    }
}
