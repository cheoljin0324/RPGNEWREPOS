using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetTrap4 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trapWall;
    [SerializeField]
    private Transform[] trapPos;
    string tagIn = "obstacle";

    void ShotTrap()
    {
        StartCoroutine(InTrap1());
    }

    IEnumerator InTrap1()
    {
        for(int i = 0; i<trapWall.Length; i++)
        {
            trapWall[i].transform.DOMove(trapPos[i].position, 0.5f,false);
            yield return new WaitForSeconds(0.5f);
        }

        for(int i = 0; i<trapWall.Length; i++)
        {
            trapWall[i].GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.5f);
            yield return new WaitForSeconds(0.5f);
            trapWall[i].tag = tagIn;
        }
    }
}
