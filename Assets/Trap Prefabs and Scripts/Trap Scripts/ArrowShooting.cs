using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    [SerializeField]
    public GameObject arrow;
    private float spawnTime = 2f;
    private float spawnTimeElapsed;
    private float speed = 20f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeElapsed -= Time.deltaTime;
        if (spawnTimeElapsed <= 0.5f)
        {
            //Debug.Log("Spawning Arrow");
            SpawnArrow();
            spawnTimeElapsed = spawnTime;
        }

    }


    public void SpawnArrow()
    {


        var newArrow = GameObject.Instantiate(arrow, transform.position, Quaternion.identity);
        rb = newArrow.GetComponent<Rigidbody>();
        newArrow.transform.SetParent(null);
        rb.AddForce((newArrow.transform.right * speed) * -1, ForceMode.Impulse);
    }
}
