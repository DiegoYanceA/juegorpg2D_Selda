﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public const int MAX_STAT_VAL = 100;
    public const int MAX_HEALTH = 9999;

    public int level;
    public int exp;
    public int[] expToLevelUp;

    [Tooltip("Niveles de vida del jugador")]
    public int[] hpLevels;

    [Tooltip("Fuerza que se suma a la arma")]
    public int[] strengthLevels;

    [Tooltip("Defensa que divide el daño del enemigo")]
    public int[] defenseLevels;

    [Tooltip("Velocidad de ataque")]
    public int[] speedLevels;

    [Tooltip("Probabilidad de que el enemigo falle")]
    public int[] luckLevels;

    [Tooltip("Probabilidad de que falle el personaje")]
    public int[] accuracyLevels;

    private HealthManager healthManager;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        playerController = GetComponent<PlayerController>();
        healthManager.UpdateMaxHealth(hpLevels[level]);

        if (gameObject.tag.Equals("Enemy"))
        {
            EnemyController controller = GetComponent<EnemyController>();
            controller.speed += speedLevels[level] / MAX_STAT_VAL;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddExperience(int exp)
    {
        if (expToLevelUp.Length <= level)
        {
            return;
        }
        
        if (expToLevelUp[level] <= this.exp)
        {
            level++;
            healthManager.UpdateMaxHealth(hpLevels[level]);
            playerController.attackTime -= speedLevels[level] / MAX_STAT_VAL;
        }

        this.exp += exp;
    }
}
