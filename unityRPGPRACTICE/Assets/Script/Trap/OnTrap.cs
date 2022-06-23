using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrap : MonoBehaviour
{
    [SerializeField]
    private int poinNumber;

    EnemyManager dungeonManager;

    private void Start()
    {
        dungeonManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("This is my Trap");
        gameObject.transform.parent.SendMessage("ShotTrap");
        if(dungeonManager.theDungeon != EnemyManager.DungeonState.Game)
        {
            GameObject.Find("EnemyManager").GetComponent<EnemyManager>().InstantObject(poinNumber);
        }

    }
}
