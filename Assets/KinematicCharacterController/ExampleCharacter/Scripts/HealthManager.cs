using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    private ExampleCharacterController controller;
    private PlayerMeleeAttackEdited playerMelee;
    private CapsuleCollider capCollider;
    private KinematicCharacterController.KinematicCharacterMotor motionControl;
    private float invincibleTime = 2f;
    private bool invincible = false;
    GameObject Player;

    [Header("Health")]
    public float startingHealth = 5f;
    public float currentHealth;
    void Awake()
    {
        Player = GameObject.Find("DogPolyart");
        controller = Player.GetComponent<ExampleCharacterController>();
        playerMelee = Player.GetComponent<PlayerMeleeAttackEdited>();
        capCollider = Player.GetComponent<CapsuleCollider>();
        motionControl = Player.GetComponent<KinematicCharacterController.KinematicCharacterMotor>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        if(invincible == false)
        {
            invincible = true;
            StartCoroutine(damageCor(damage));
        }
    }
    IEnumerator damageCor(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        Debug.Log("Health Amount: " + currentHealth);

        if (currentHealth > 0)
        {
            Debug.Log("Player Take" + damage + "Damage");
            yield return new WaitForSeconds(invincibleTime);
            invincible = false;
        }
        else
        {
            Debug.Log("Player had Died");
            controller.enabled = false;
            playerMelee.Alive = false;
            capCollider.enabled = false;
            motionControl.enabled = false;
            controller.Anim.Play("Die");
            controller.TransitionToState(CharacterState.Dead);
            yield return new WaitForSeconds(1.5f);
            controller.enabled = true;
            playerMelee.Alive = true;
            capCollider.enabled = true;
            motionControl.enabled = true;
            controller.Motor.SetPosition(controller.spawnLocation);
            controller.TransitionToState(CharacterState.Default);
            controller.Anim.Play("Idle_Battle");
            currentHealth = startingHealth;
            invincible = false;
        }
    }
}