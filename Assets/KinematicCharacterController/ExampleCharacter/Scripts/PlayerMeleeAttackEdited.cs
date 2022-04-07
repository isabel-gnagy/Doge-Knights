using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackEdited : MonoBehaviour
{
    public bool Alive = true;
    private PlayerSettings playerSettings;
    [Tooltip("The box that extends to create the player's attack will use this point as its center. Note that forward position will automatically be" +
        "additionally offset by half the attack area's length")]
    public Transform attackOrigin;


    [Tooltip("Cube to draw the attack area when debug mode is enabled")]
    public GameObject debugAreaCube;
    [Tooltip("Prefab to draw hit indicators when debug mode is enabled")]
    public GameObject debugHitCube;

    public bool enableDebugMode = true;
    private bool canAttack = true;
    private bool _isFirstAttack = true;
    private Animator Anim;

    /// <summary>
    /// The time (relative to Time.time) when we can attack again. A simpler alternative to cooldowns
    /// when you all you want is a simple periodic event with no associated UI (a cooldown wheel, etc)
    /// and don't mind paying a small performance hit (very small)
    /// </summary>
    private float nextAttackPossible = 0f;

    void Start()
    {
        Anim = GetComponent<Animator>();
        playerSettings = PlayerSettings.getInstance();
    }

    void Update()
    {
        //Position the debug cube where the attack zone will be
        if (enableDebugMode)
        {
            debugAreaCube.transform.position = attackOrigin.position + transform.forward * playerSettings.MeleeAttackLength / 2;
            //Exactly double the size used for the physics event. The debug cube must be a root object (no parent)
            debugAreaCube.transform.localScale = new Vector3(playerSettings.MeleeAttackWidth, 5f, playerSettings.MeleeAttackLength);
            debugAreaCube.transform.rotation = attackOrigin.transform.rotation;
        }
        if (Time.time > nextAttackPossible)
        {
            canAttack = true;
        }
    }


    /// <summary>
    /// Executes a melee attack in front of the character
    /// </summary>
    public void Attack()
    {
        if (Alive)
        {
            if (!canAttack)
            {
                return;
            }

            //Handle Attacking Animation
            if (_isFirstAttack)
            {
                print("Attack-1");
                _isFirstAttack = false;
                Anim.PlayInFixedTime("Attack01");
            }
            else
            {
                print("Attack-2");
                _isFirstAttack = true;
                Anim.PlayInFixedTime("Attack02");
            }

            canAttack = false;
            nextAttackPossible = Time.time + playerSettings.MeleeAttackCooldown;

            int layerMask = LayerMask.GetMask("Enemy");
            Collider[] hits = Physics.OverlapBox(
                attackOrigin.position + transform.forward * playerSettings.MeleeAttackLength / 2,
                //Note that some smoothbrain decided that overlapBox would take a HALF size as the second arg!
                new Vector3(playerSettings.MeleeAttackWidth, 5f, playerSettings.MeleeAttackLength) / 2,
                attackOrigin.transform.rotation,
                layerMask
                );

            for (int i = 0; i < hits.Length; i++)
            {
                if (enableDebugMode)
                {
                    GameObject hitCube = Instantiate(debugHitCube, hits[i].transform.position + new Vector3(0f, 3f, 0f), Quaternion.identity);
                    hitCube.transform.parent = hits[i].transform; //allows markers to follow the thing that was hit
                }
                //Health component should always be attached to the root for simplicity
                EnemyDamage EnemyScript = hits[i].transform.GetComponent<EnemyDamage>();
                if (EnemyScript != null)
                {
                    Debug.Log("damaging: " + hits[i].transform.gameObject.name);
                    Vector3 direction = (transform.position - hits[i].transform.position).normalized;
                    if (!_isFirstAttack)
                    {
                        EnemyScript.TakeDamage(1f);
                    }
                    else
                    {
                        EnemyScript.TakeDamage(2f);
                    }
                }
            }
        }
    }
}
