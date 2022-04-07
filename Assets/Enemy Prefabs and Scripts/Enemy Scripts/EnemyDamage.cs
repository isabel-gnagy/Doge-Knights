using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    private float damageAmount = 1f;
    private GameObject Player;
    private float EnemyHealth = 2f;
    public bool attacking = false;
    private bool midAnimation = false;
    private HealthManager playerHealth;


    void Update() {
        
    }
    void Awake()
    {
        Player = GameObject.Find("DogPolyart");
        playerHealth = Player.GetComponent<HealthManager>();
    }

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }
    public void startAttackingPlayer()
    {
        if (!midAnimation)
        {
            midAnimation = true;
            StartCoroutine(AttackingPlayer());
        }
    }
    public IEnumerator AttackingPlayer()
    {
        Debug.Log("Attacking Player");
        StartCoroutine(MoveOverSeconds(gameObject.transform.GetChild(0).gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f, gameObject.transform.position.z), 2f));
        yield return new WaitForSeconds(1);
        if (attacking)
        {
            StartCoroutine(MoveOverSeconds(gameObject.transform.GetChild(0).gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.7f, gameObject.transform.position.z + 2f), 1f));
            DealDamage();
            yield return new WaitForSeconds(1);
            StartCoroutine(MoveOverSeconds(gameObject.transform.GetChild(0).gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), 0f));
            StartCoroutine(AttackingPlayer());
        }
        else
        {
            StartCoroutine(MoveOverSeconds(gameObject.transform.GetChild(0).gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.7f, gameObject.transform.position.z + 2f), 1f));
            yield return new WaitForSeconds(1);
            StartCoroutine(MoveOverSeconds(gameObject.transform.GetChild(0).gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), 0f));
        }
        midAnimation = false;
    }

    public void TakeDamage(float damage)
    {
        EnemyHealth -= damage;
        Debug.Log("Enemy Damaged by Player");
        if (EnemyHealth <= 0)
        {
            Debug.Log("Enemy Dies");
            gameObject.active = false;
        }
    }

    public void DealDamage()
    {
        Debug.Log(" Player Damaged by " + damageAmount);
        playerHealth.TakeDamage(damageAmount);
        Debug.Log("Player Health = " + playerHealth.currentHealth);
    }

}
