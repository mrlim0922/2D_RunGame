using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject gamaManager;

    void Awake()
    {
        gamaManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    //충돌처리.
    void OnTriggerEnter2D(Collider2D other) //충돌판정 
    {
        if (DataManager.Instance.playerDie == false)
        {

            if (other.gameObject.tag.CompareTo("Player") == 0)
            {
                gamaManager.GetComponent<GameManager>().Load_Stage();
            }
        }

    }
}
