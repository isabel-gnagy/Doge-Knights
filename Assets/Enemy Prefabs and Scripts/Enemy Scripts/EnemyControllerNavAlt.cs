using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerNavAlt : MonoBehaviour
{

    /// <summary>
    /// Updated from:
    /// https://gamedevacademy.org/tutorial-multi-level-platformer-game-in-unity/#Enemy_movement
    /// </summary>

    // Range of movement
    public float rangeY = 3f;
    // Speed
    public float speed = 3f;
    // Initial direction
    public float direction = 1f;

    public bool startJump = true;
    // To keep the initial position
    Vector3 initialPosition;
    Quaternion initialRotation;

    Coroutine fishCO;

    void Awake()
    {
        // Initial location in Y
        initialPosition = transform.position;
    }

    void Update()
    {
        if (startJump)
        {
            fishCO = StartCoroutine("fishJump");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(fishCO);
            startJump = false;
            transform.position = initialPosition;
            startJump = true;
        }
    }

    IEnumerator fishJump()
    {

        // How much we are moving
        float movementY = direction * speed * Time.deltaTime;
        // New position
        float newY = transform.position.y + movementY;

        // Check whether the limit would be passed
        if (Mathf.Abs(newY - initialPosition.y) > rangeY)
        {
            // Move the other way
            direction *= -1;
        }
        // If it can move further, move
        else
        {
            // Move the object
            transform.Translate(new Vector3(0, movementY, 0));
        }
        if (transform.position.y <= initialPosition.y)
        {
            startJump = false;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            startJump = true;
            transform.Translate(new Vector3(0, 1f, 0));
            direction = 1f;
        }
    }
}
