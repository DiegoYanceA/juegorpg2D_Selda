﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<GameObject> weapons;
    public int activeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
       foreach(Transform weapon in transform)
        {
            weapons.Add(weapon.gameObject);
        } 

       //for(int i = 0; i < weapons.Count; i++)
       // {
       //     weapons[i].SetActive(i == activeWeapon);
       // }
    }

    public List<GameObject> GetAllWeapons()
    {
        return weapons;
    }

    public void ChangeWeapon(int newWeapon)
    {
        weapons[activeWeapon].SetActive(false);
        weapons[newWeapon].SetActive(true);
        activeWeapon = newWeapon;
    }
}
