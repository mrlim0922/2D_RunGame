using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZon : MonoBehaviour
{

    public GameObject GamaManager;
    public GameObject LoadMap;

    //충돌처리.
    void OnTriggerEnter2D(Collider2D other) //충돌판정 
    {
        if (DataManager.Instance.playerDie == false)
        {

            if (other.gameObject.tag.CompareTo("Player") == 0)
            {
                GamaManager.GetComponent<GameManager>().Next_Stage();
                Invoke("Close", 3f);
            }
        }

    }

    void Close()
    {
        LoadMap.SetActive(false);
    }
}
