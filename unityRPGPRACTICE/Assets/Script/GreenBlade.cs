using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlade : AttackBlade
{
    Test PlayerT;
    Transform PlayerTransform;
    [SerializeField]
    private GameObject SetOb;

    private void Start()
    {
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        PlayerT = GetComponentInParent<Test>();
        PlayerTransform = GetComponentInParent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Skill1();
        }
    }


    protected override void Skill1()
    {
        GameObject Desh;

        Desh = Instantiate(SetOb);
        PlayerTransform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, PlayerTransform.position.z + 10);

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