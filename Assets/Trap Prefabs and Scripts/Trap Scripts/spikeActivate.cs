using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeActivate : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        StartCoroutine(trapActivate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private IEnumerator trapActivate()
    {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject spike in spikes)
        {
            rb = spike.GetComponent<Rigidbody>();
            rb.AddForce((spike.transform.right * 5f) * -1, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(2f);

        foreach (GameObject spike in spikes)
        {
            spike.transform.position = new Vector3(spike.transform.position.x, spike.transform.position.y, spike.transform.position.z - 2.7f) * Time.deltaTime;
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(trapActivate());
    }

}
