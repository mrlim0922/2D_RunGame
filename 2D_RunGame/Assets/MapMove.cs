using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float mapSpeed = 3f;

    void Update()
    {
        if (DataManager.Instance.playerDie == false)
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }

    }

}