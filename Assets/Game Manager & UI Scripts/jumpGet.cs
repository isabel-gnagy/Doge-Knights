using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class jumpGet : MonoBehaviour
{
    GameObject player;
    Text jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        jumpCount = gameObject.GetComponent<Text>();
        player = GameObject.Find("DogPolyart");
    }

    // Update is called once per frame
    void Update()
    {
        float num = Mathf.Abs(2 - player.GetComponent<ExampleCharacterController>().jumpCount);
        string v = "Jumps : " + num;
        jumpCount.text = v;
    }
}
