using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("game over");
            SceneManager.LoadScene("GameEnd");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.UnloadSceneAsync(gameObject.scene);    
         }
    }
}
