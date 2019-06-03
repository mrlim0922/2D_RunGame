using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (DataManager.Instance.playerDie == false && DataManager.Instance.magnetTimeCurrent > 0)
        {
            if (distance < 3)
            {
                //이동.
                Vector2 dir = player.transform.position - transform.position;
                transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
            }

        }
    }





    //충돌처리.
    void OnTriggerEnter2D(Collider2D other) //충돌판정 
    {
        if (DataManager.Instance.playerDie == false)
        {

            if (other.gameObject.tag.CompareTo("Player") == 0) 
            {
                SoundManager.Instance.PlaySound("Coin");
                DataManager.Instance.score += 1;
                Destroy(gameObject);
            }
        }

    }

}