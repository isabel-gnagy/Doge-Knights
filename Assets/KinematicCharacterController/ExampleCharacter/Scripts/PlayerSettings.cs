using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A singleton that tracks various properties of the player, such as attack damage
/// </summary>
public class PlayerSettings {
    [Tooltip("Cooldown, in seconds, between player melee attack swings")]
    public float MeleeAttackCooldown = 1f;
    [Tooltip("Width (player left/right) of the melee attack area, in relative scale")]
    public float MeleeAttackWidth = 1.5f;
    [Tooltip("Length (player forward) of the melee attack area, in relative scale")]
    public float MeleeAttackLength = 1.5f;
    [Tooltip("Melee Attack Damage")]
    public int MeleeAttackDamage = 2;

    private static PlayerSettings instance;

    public static PlayerSettings getInstance() {
        if (instance == null) {
            instance = new PlayerSettings();
        }
        return instance;
    }
}
