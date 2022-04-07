using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.transform.parent.gameObject.GetComponent<EnemyDamage>().attacking= true;
            gameObject.transform.parent.gameObject.GetComponent<EnemyDamage>().startAttackingPlayer();
            Debug.Log("Player Found");
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.transform.parent.gameObject.GetComponent<EnemyDamage>().attacking = true;
            gameObject.transform.parent.gameObject.GetComponent<EnemyDamage>().startAttackingPlayer();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.transform.parent.gameObject.GetComponent<EnemyDamage>().attacking = false;
            Debug.Log("Player Left");
        }
    }
}