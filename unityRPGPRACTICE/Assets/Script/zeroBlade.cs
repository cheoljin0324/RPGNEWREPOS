using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class zeroBlade : AttackBlade
{
    Test PlayerT;
    [SerializeField]
    private GameObject ShildSet;

    private void Start()
    {
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        PlayerT = GetComponentInParent<Test>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Skill1();
        }
    }

    IEnumerator SetShild()
    {
        GameObject Shild = Instantiate(ShildSet,GameObject.Find("Player").transform);
        Shild.transform.localScale = new Vector3(0, 0, 0);
        Shild.transform.position = gameObject.transform.position;
        Shild.GetComponent<MeshRenderer>().material.color = new Color(1, 236 / 255f, 0, 0.1f);

        Shild.transform.DOScale(new Vector3(3, 3, 3), 1);

        yield return new WaitForSeconds(5f);
        Shild.GetComponent<MeshRenderer>().material.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(Shild);
    }


    protected override void Skill1()
    {
        StartCoroutine(SetShild());
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