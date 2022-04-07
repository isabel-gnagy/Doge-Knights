using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretActivate : MonoBehaviour
{
    GameObject turret;
    void Awake()
    {
        turret = gameObject.transform.GetChild(0).gameObject;
        transform.DetachChildren();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            turret.GetComponent<EnemyControllerTurret>().playerInRange = true;
            Debug.Log("Player Found");
            transform.DetachChildren();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            turret.GetComponent<EnemyControllerTurret>().playerInRange = false;
            Debug.Log("Player Left");
        }
    }
}
