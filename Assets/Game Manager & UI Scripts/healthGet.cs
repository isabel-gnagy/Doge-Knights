using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthGet : MonoBehaviour
{
    GameObject player;
    Text health;
    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Text>();
        player = GameObject.Find("DogPolyart");
    }

    // Update is called once per frame
    void Update()
    {
        string v = "Health : " + player.GetComponent<HealthManager>().currentHealth;
        health.text = v;
    }
}