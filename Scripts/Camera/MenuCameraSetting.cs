using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraSetting : MonoBehaviour
{
    public GameObject target,targetVehicleShop,targerShop,targetWeaponShop,targetFishShop, TargetItemShop; // The target GameObject
    public float speed = 0.5f; // Speed of the movement

    private void Start()
    {
        if (target != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime * speed);
        }
    }
    void Update()
    {
        if (MainMeneManager.isHomeScreen)
        {
            toHomeMenu();
        }
        if (MainMeneManager.isStoreScreen)
        {
            toStore();
        }
        if (MainMeneManager.isFishScreen)
        {
            toFishShop();
        }
        if (MainMeneManager.isItemScreen)
        {
            toItmeShop();
        }
        if (MainMeneManager.isWeaponscreen)
        {
            toWeaponShop();
        }
        if (MainMeneManager.isVehicleScreen)
        {
            toVehicleShop();
        }

    }
    void toStore()
    {
        if (targerShop != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, targerShop.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targerShop.transform.rotation, Time.deltaTime * speed);
        }
    }
    void toWeaponShop()
    {
        if (targetWeaponShop != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, targetWeaponShop.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetWeaponShop.transform.rotation, Time.deltaTime * speed);
        }
    }
    void toFishShop()
    {
        if (targetFishShop != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, targetFishShop.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetFishShop.transform.rotation, Time.deltaTime * speed);
        }
    }
    void toVehicleShop()
    {
        if (targetVehicleShop != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, targetVehicleShop.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetVehicleShop.transform.rotation, Time.deltaTime * speed);
        }
    }
    void toItmeShop()
    {
        if (TargetItemShop != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, TargetItemShop.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetItemShop.transform.rotation, Time.deltaTime * speed);
        }
    }
    void toHomeMenu()
    {
        if (target != null)
        {
            // Smoothly move towards the target's position
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

            // Smoothly rotate towards the target's rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime * speed);
        }
    }

}
