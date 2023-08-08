using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitch : MonoBehaviour
{
    public int weaponSelected = 0;

    Keyboard kboard = Keyboard.current;
    void Start()
    {
        selectWeapon();
    }

    void Update()
    {
        if (kboard.digit1Key.wasPressedThisFrame)
        {
            weaponSelected = 0;
            Debug.Log("pressed 1");
            selectWeapon();
        }
        if (kboard.digit2Key.wasPressedThisFrame && transform.childCount >= 2)
        {
            weaponSelected = 1;
            Debug.Log("pressed 2");
            selectWeapon();
        }
        if (kboard.digit3Key.wasPressedThisFrame && transform.childCount >= 3)
        {
            weaponSelected = 2;
            Debug.Log("pressed 3");
            selectWeapon();
        }
        if (kboard.digit4Key.wasPressedThisFrame && transform.childCount >= 4)
        {
            weaponSelected = 3;
            Debug.Log("pressed 4");
            selectWeapon();
        }
    }

    void selectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == weaponSelected)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
