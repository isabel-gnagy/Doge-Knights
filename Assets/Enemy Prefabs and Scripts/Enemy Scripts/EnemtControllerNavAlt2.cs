using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtControllerNavAlt2 : MonoBehaviour{


    /// <summary>
    /// Updated from:
    /// https://gamedevacademy.org/tutorial-multi-level-platformer-game-in-unity/#Enemy_movement
    /// </summary>

    // Range of movement
    public float rangeX = 2f;
    // Speed
    public float speed = 3f;
    // Initial direction
    public float direction = 1f;
    // To keep the initial position
    Vector3 initialPosition;

    void Start() {
        // Initial location in X
        initialPosition = transform.position;
    }

    void Update() {
        // How much we are moving
        float movementX = direction * speed * Time.deltaTime;
        // New position
        float newX = transform.position.x + movementX;

        // Check whether the limit would be passed
        if (Mathf.Abs(newX - initialPosition.x) > rangeX) {
            // Move the other way
            direction *= -1;
        }
        // If it can move further, move
        else {
            // Move the object
            transform.Translate(new Vector3(movementX, 0, 0));
        }
    }


    public void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player")) {
            Debug.Log("Player DeD");
        }
    }
}
