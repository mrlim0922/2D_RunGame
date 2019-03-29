using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float jump = 3f;
    public float jump2 = 3.5f;

    int jumpCount = 0;



    public void JumpButton()
    {
        if (DataManager.Instance.playerDie == false)
        {
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0)  //이중점프.
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                jumpCount += 1;  //이중점프 카운트.
            }

            else if (jumpCount == 1)  //이중점프.
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                jumpCount += 1;  //이중점프 카운트.
            }
        }

    }

    //충돌처리.
    void OnCollisionEnter2D(Collision2D other) //충돌판정.
    {

        if (other.gameObject.tag.CompareTo("Land") == 0) // Land 판단
        {
            jumpCount = 0;
        }

        if (other.gameObject.tag.CompareTo("Block") == 0) // Block 판단
        {
            DataManager.Instance.playTimeCurrent -= 3f;
        }


    }
}