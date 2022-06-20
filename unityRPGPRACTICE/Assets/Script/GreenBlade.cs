using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlade : AttackBlade
{
    Test PlayerT;

    private void Start()
    {
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        PlayerT = GetComponentInParent<Test>();
    }


    protected override void Skill1()
    {
        Debug.Log("BlueSword Active");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            CameraShake.CameraShaking();
            other.gameObject.SendMessage("Damage", PlayerT.attack);
        }
    }
}