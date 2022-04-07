using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour{

    public float missileSpeed;
    private Rigidbody rb;

    public bool isHoming = true;
    private Vector3 toTarget;
    private GameObject homingTarget;

    void Start(){

        rb = GetComponent<Rigidbody>();
        //homingTarget = GameObject.Find("DogPolyart");
        
    }

    void Awake() {
        rb = GetComponent<Rigidbody>();
        homingTarget = GameObject.Find("DogPolyart");
        toTarget = (homingTarget.transform.position - transform.position);

        Quaternion rotation = Quaternion.LookRotation(toTarget, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100f);
       
    }

    void Update(){
        
    }

    private void FixedUpdate() {
        

        if (isHoming) {
            //Normalizing the vector to mag 1 lets us apply a constant acceleration towards the target
            //If you prefer to accelerate fast, then slower, you could use the actual vector

            toTarget = (homingTarget.transform.position - transform.position);
            rb.AddForce(toTarget * missileSpeed);
            //The need for rotation here was avoidable: We should have made the display part of the missile
            //seperate from the logic, as a child that's rotated 90 degrees.
            Quaternion rotation = Quaternion.LookRotation(toTarget, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100f);
        }
        else {

            //Vector3 toTarget = (homingTarget.transform.position - transform.position);
            rb.AddForce(toTarget * missileSpeed);
        }
    }

    public void setHomingTarget(GameObject target) {
        homingTarget = target;
    }
}
